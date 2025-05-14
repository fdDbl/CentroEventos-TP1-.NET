namespace CentroEventos.Aplicacion;

public class ReservarActividadUseCase(IRepositorioReserva repoR, IRepositorioEventoDeportivo repoE, IRepositorioPersona repoP, ReservaValidador validador)
{
    public void Ejecutar(Reserva reserva)
    {
        if (!validador.ValidarReserva(reserva,repoR,repoE,repoP,out string msg)){
            throw new ValidacionException(msg);
        }
        repoR.AltaReserva(reserva);
    }
}