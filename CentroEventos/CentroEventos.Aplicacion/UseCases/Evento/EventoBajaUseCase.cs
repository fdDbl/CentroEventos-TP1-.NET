namespace CentroEventos.Aplicacion;

public class EventoBajaUseCase(IServicioAutorizacion auth,IRepositorioEventoDeportivo repoEventos,
                                IRepositorioReserva repoReservas, EventoBaja_ValidadorReservasAsociadas validadorReservasAsociadas)
{
    public void Ejecutar(EventoDeportivo evento, int userId)
    {
        string msg:
        if (!auth.PoseeElPermiso(userId, Permiso.EventoBaja)) 
            throw new FalloAutorizacionException("No posee los permisos para dar de baja un evento.");
        if (!validadorReservasAsociadas(evento,repoReservas,msg)) throw new OperacionInvalidaException(msg);
        repoEventos.EventoBaja(evento.Id); //En el repo evalúo si existe el Id y si no, lanzo una EntidadNotFoundException
    }
}