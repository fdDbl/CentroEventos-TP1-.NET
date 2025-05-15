namespace CentroEventos.Aplicacion;

public class ReservaModificarUseCase(IServicioAutorizacion auth,IRepositorioReserva repoR, IRepositorioEventoDeportivo repoE, IRepositorioPersona repoP, ReservaModificarValidador validador)
{
    public void Ejecutar(Reserva reserva, int idUser)
    {
        if (auth.PoseeElPermiso(idUser, Permiso.ReservaModificacion))
        {
            if (!validador.Validar(reserva, repoR, repoE, repoP, out string msg))
            {
                throw new ValidacionException(msg);
            }
        }
        else throw new FalloAutorizacionException("No posee los permisos para modificar una reserva.");

        repoR.ModificarReserva(reserva);
    }
}