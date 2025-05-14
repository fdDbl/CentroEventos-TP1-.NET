using CentroEventos.Aplicacion.validators;
namespace CentroEventos.Aplicacion;

public class BajaActividadUseCase(IRepositorioEventoDeportivo repoEventos,IRepositorioReserva repoReservas, EventoBajaValidador validador)
{
    public void Ejecutar(EventoDeportivo evento)
    {
        if (!validador.ValidarEventoBaja(evento,repoEventos,repoReservas,out string msg)) 
            throw new Exception(msg);
        repoEventos.EventoBaja(evento.Id); //La baja se hace por Id del evento, asi que le mando por parámetro el id 
    }
}