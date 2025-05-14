namespace CentroEventos.Aplicacion;

public class ReservaValidador
{
    public bool ValidarReserva(Reserva reserva, IRepositorioReserva repoReserva, IRepositorioEventoDeportivo repoEvento, IRepositorioPersona repoPersona, out string msg)
    {
        msg = "";
        if(repoPersona.ObtenerPersona(reserva.PersonaId) == null || repoEvento.ObtenerEvento(reserva.EventoDeportivoId) == null)
            msg += "Persona y/o Evento Deportivo no existentes.\n";
        
        var lista = repoReserva.ListarReservas();
        Reserva? rCheck;
        int pId = reserva.PersonaId;
        int eId = reserva.EventoDeportivoId;
        rCheck = lista.Find(r => r.PersonaId == pId && r.EventoDeportivoId == eId);
        if(rCheck != null)
            msg += "La persona no puede reservar dos veces el mismo Evento Deportivo.\n";

        int cantReservasEvento = 0;
        foreach(Reserva r in lista)
            if (r.EventoDeportivoId == reserva.EventoDeportivoId) cantReservasEvento++;
        if(cantReservasEvento > repoEvento.ObtenerEvento(reserva.EventoDeportivoId).CupoMaximo)
            msg += "No hay cupo disponible para el evento que se desea reservar.\n";
        
        return msg == "";
    }
}