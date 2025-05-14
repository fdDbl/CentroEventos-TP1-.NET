namespace CentroEventos.Aplicacion;

public class ReservaAltaUseCase(IRepositorioReserva repoR, IRepositorioEventoDeportivo repoE, IRepositorioPersona repoP, ReservaAltaValidador altaValidador)
{
    public void Ejecutar(Reserva reserva)
    {
        if (!altaValidador.ValidarReserva(reserva,repoR,repoE,repoP,out string msg)){
            throw new ValidacionException(msg);
        }
        repoR.AltaReserva(reserva);
    }
}