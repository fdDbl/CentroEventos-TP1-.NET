namespace CentroEventos.Aplicacion;

public class ReservaValidador
{
    public bool ValidarReserva(Reserva reserva, IRepositorioReserva repoReserva, IRepositorioEventoDeportivo repoEvento, IRepositorioPersona repoPersona, out string msg)
    {
        msg = "";
        if(repoPersona.ObtenerPersona(reserva.PersonaId) == null || repoEvento.ObtenerEvento(reserva.EventoDeportivoId) == null)
            msg += "Persona y/o Evento Deportivo no existentes.\n";
    }
}