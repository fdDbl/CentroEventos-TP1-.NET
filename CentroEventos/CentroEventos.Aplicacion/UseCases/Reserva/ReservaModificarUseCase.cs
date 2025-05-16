namespace CentroEventos.Aplicacion;

public class ReservaModificarUseCase(IServicioAutorizacion auth,IRepositorioReserva repoR, IRepositorioEventoDeportivo repoE, IRepositorioPersona repoP, ReservaModificarValidador_Existentes validadorExistentes)
{
    public void Ejecutar(Reserva reserva, int idUser)
    {
        if (!auth.PoseeElPermiso(idUser, Permiso.ReservaModificacion)) throw new FalloAutorizacionException("No posee los permisos para modificar una reserva.");
        if (!validadorExistentes.Validar(reserva, repoR, repoE, repoP, out string msg)) throw new EntidadNotFoundException(msg);
        
        repoR.ModificarReserva(reserva);
    }
}