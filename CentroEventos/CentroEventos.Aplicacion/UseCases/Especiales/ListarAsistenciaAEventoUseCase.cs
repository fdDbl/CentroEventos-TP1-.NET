namespace CentroEventos.Aplicacion;

public class ListarAsistenciaAEventoUseCase (IRepositorioReserva unRepoR, IRepositorioPersona per) {

    public List<Persona> Ejecutar(EventoDeportivo unEvento) {
        var listaP = new List<Persona>();
        if (unEvento.FechaHoraInicio < DateTime.Now)
        {
            var listaPresentes = new List<Reserva>();
            foreach (Reserva r in unRepoR.ListarReservas())
            {
                if (r.EventoDeportivoId == unEvento.Id && r.EstadoAsistencia == Asistencia.Presente) 
                {           
                    listaPresentes.Add(r);
                }
            }
            foreach (Reserva r in listaPresentes) 
            {
                Persona? p = per.ObtenerPersona(r.PersonaId); 
                if (p != null)
                {
                    listaP.Add(p); 
                }
            }
        }
        return listaP; 
    }
}