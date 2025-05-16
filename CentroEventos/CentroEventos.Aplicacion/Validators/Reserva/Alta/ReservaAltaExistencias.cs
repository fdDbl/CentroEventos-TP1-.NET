namespace CentroEventos.Aplicacion;

public class ReservaAltaExistencias
{
    public bool Validar(Reserva reserva, IRepositorioPersona repoPersona, IRepositorioEventoDeportivo repoEvento, out string msg)
    {
        msg = "";
        
        if(repoPersona.ObtenerPersona(reserva.PersonaId) == null || repoEvento.ObtenerEvento(reserva.EventoDeportivoId) == null)
            msg += "Persona y/o Evento Deportivo no existente(s).\n";

        return msg == "";
    }
}