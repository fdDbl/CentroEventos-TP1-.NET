namespace CentroEventos.Aplicacion;

public class EventoBajaUseCase(IServicioAutorizacion auth,IRepositorioEventoDeportivo repoEventos,
                                IRepositorioReserva repoReservas, EventoBajaValidadorReservasAsociadas validadorReservasAsociadas)
{
    public void Ejecutar(int eventoId, int userId) //
    {
        string msg;
        if (!auth.PoseeElPermiso(userId, Permiso.EventoBaja)) 
            throw new FalloAutorizacionException("No posee los permisos para dar de baja un evento.");
        if (!validadorReservasAsociadas.Validar(eventoId,repoReservas,out msg)) throw new OperacionInvalidaException(msg);
        repoEventos.EventoBaja(eventoId); //En el repo evalúo si existe el Id y si no, lanzo una EntidadNotFoundException
    }
}