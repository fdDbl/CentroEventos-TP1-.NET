namespace CentroEventos.Aplicacion;

public class ReservaAltaValidador
{
    public bool Validar(Reserva reserva, IRepositorioReserva repoReserva, IRepositorioEventoDeportivo repoEvento, IRepositorioPersona repoPersona, out string msg)
    {
        msg = "";
        
        if(repoPersona.ObtenerPersona(reserva.PersonaId) == null || repoEvento.ObtenerEvento(reserva.EventoDeportivoId) == null)
            msg += "Persona y/o Evento Deportivo no existente(s).\n";
        

        
        if (repoReserva.ContarReserva(reserva.EventoDeportivoId) == repoEvento.ObtenerEvento(reserva.EventoDeportivoId)?.CupoMaximo)
            msg += "No hay cupo disponible para el evento que se desea reservar.\n";

        return msg == "";
    }
}