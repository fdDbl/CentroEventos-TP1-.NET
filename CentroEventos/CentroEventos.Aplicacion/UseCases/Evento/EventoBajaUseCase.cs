using CentroEventos.Aplicacion.validators;
namespace CentroEventos.Aplicacion;

public class BajaActividadUseCase(IRepositorioEventoDeportivo repo,IRepositorioReserva repoReservas, EventoBajaValidador validador)
{
    public void Ejecutar(EventoDeportivo evento)
    {
        if (!validador.ValidarEventoBaja(evento,repoReservas,out string msg))
            throw new Exception(msg);
        repo.EventoBaja(evento);
    }
}