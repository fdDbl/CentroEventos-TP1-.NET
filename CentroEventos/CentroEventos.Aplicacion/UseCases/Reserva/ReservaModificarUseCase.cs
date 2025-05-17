namespace CentroEventos.Aplicacion;

public class ReservaModificarUseCase(IServicioAutorizacion auth,IRepositorioReserva repoR, IRepositorioEventoDeportivo repoE, IRepositorioPersona repoP, ReservaValidadorModificarExistentes existentes)
{
    public void Ejecutar(Reserva reserva, int idUser)
    {
        if (!auth.PoseeElPermiso(idUser, Permiso.ReservaModificacion)) throw new FalloAutorizacionException("No posee los permisos para modificar una reserva.");
        if (!existentes.Validar(reserva, repoR, repoE, repoP, out string msg)) throw new EntidadNotFoundException(msg);
        
        repoR.ModificarReserva(reserva);
    }
}