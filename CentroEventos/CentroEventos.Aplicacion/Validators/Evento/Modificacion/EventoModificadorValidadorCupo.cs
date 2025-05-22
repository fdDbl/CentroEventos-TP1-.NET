namespace CentroEventos.Aplicacion;

public class EventoModificadorValidadorCupo
{
    public bool ValidarEventoModificacionCupoMax (EventoDeportivo unEvento, IRepositorioReserva unRepo, out string msg)
    {
        msg = "";
        if (!(unRepo.ContarReserva(unEvento.Id) < unEvento.CupoMaximo))
        {
            msg += "Hay mas reservas del nuevo cupo maximo que se pretende ingresar.\n";
        }
        return msg == "";
    }
}