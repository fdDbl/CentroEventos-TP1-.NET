namespace CentroEventos.Aplicacion;

public class ReservaAltaDuplicado
{
    public bool Validar(Reserva reserva, IRepositorioReserva repoReserva, out string msg)
    {
        msg = "";
        
        var lista = repoReserva.ListarReservas();
        Reserva? rCheck;
        int pId = reserva.PersonaId;
        int eId = reserva.EventoDeportivoId;
        rCheck = lista.Find(r => r.PersonaId == pId && r.EventoDeportivoId == eId);
        if (rCheck != null)
            msg += "La persona no puede reservar dos veces el mismo Evento Deportivo.\n";

        return msg == "";
    }
}