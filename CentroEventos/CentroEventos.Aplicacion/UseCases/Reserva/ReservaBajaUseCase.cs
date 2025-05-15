namespace CentroEventos.Aplicacion;

public class ReservaBajaUseCase(IServicioAutorizacion auth, IRepositorioReserva repoR, ReservaBajaValidador validador)
{
    public void Ejecutar(int idReserva, int idUser)
    {
        if (auth.PoseeElPermiso(idUser, Permiso.ReservaBaja))
        {
            if (!validador.Validar(idReserva, repoR, out string msg)) throw new ValidacionException(msg);
            repoR.BajaReserva(idUser);
            
        }
        else throw new FalloAutorizacionException("No posee los permisos para hacer baja de una reserva.");
    }
}