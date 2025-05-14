namespace CentroEventos.Aplicacion;

public class ReservaModificarUseCase(IRepositorioReserva repoR, IRepositorioEventoDeportivo repoE, IRepositorioPersona repoP, ReservaModificarValidador validador)
{
    public void Ejecutar(Reserva reserva)
    {
        if (!validador.ValidarReserva(reserva,repoR,out string msg)){
            throw new ValidacionException(msg);
        }
        repoR.AltaReserva(reserva);
    }
}