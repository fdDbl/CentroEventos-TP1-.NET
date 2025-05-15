namespace CentroEventos.Aplicacion;

public class ReservaAltaUseCase(IServicioAutorizacion auth, IRepositorioReserva repoR, IRepositorioEventoDeportivo repoE, IRepositorioPersona repoP, ReservaAltaValidador validador)
{
    public void Ejecutar(Reserva reserva, int idUser)
    {
        if (auth.PoseeElPermiso(idUser, Permiso.ReservaAlta))
        {
            if (!validador.Validar(reserva, repoR, repoE, repoP, out string msg))
            {
                throw new ValidacionException(msg);
            }
        }
        else throw new FalloAutorizacionException("No posee los permisos para hacer alta de una reserva.");

        repoR.AltaReserva(reserva);
    }
}