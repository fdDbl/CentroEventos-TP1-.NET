namespace CentroEventos.Aplicacion;

public class ReservaAlta_CupoDisponible
{
    public bool Validar(Reserva reserva, IRepositorioReserva repoReserva, IRepositorioEventoDeportivo repoEvento, out string msg)
    {
        msg = "";
        
        if (repoReserva.ContarReserva(reserva.EventoDeportivoId) == repoEvento.ObtenerEvento(reserva.EventoDeportivoId)?.CupoMaximo)
            msg += "No hay cupo disponible para el evento que se desea reservar.\n";

        return msg == "";
    }
}