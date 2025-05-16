using CentroEventos.Aplicacion.validators;
namespace CentroEventos.Aplicacion;

public class EventoBajaUseCase(IServicioAutorizacion auth,IRepositorioEventoDeportivo repoEventos,IRepositorioReserva repoReservas, EventoBajaValidador validador)
{
    public void Ejecutar(EventoDeportivo evento, int userId)
    {
        if (auth.PoseeElPermiso(userId, Permiso.EventoBaja))
        {
            if (!validador.ValidarEventoBaja(evento, repoEventos, repoReservas, out string msg))
                throw new Exception(msg);
            repoEventos.EventoBaja(evento.Id); //La baja se hace por Id del evento, asi que le mando por parámetro el id 
        }
    }
}