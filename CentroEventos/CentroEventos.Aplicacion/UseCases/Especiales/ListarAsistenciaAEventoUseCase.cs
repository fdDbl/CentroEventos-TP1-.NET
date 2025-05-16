namespace CentroEventos.Aplicacion.UseCases.Actividad;

public class ListarAsistenciaAEventoUseCase (EventoDeportivo unEvento, IRepositorioReserva unRepoR, IRepositorioPersona per) {

    public List<Persona> Ejecutar() {
        var listaP = new List<Persona>();
        if (unEvento.FechaHoraInicio < DateTime.Now) // evaluo si el evento es pasado
        {
            var listaPresentes = new List<Reserva>();
            foreach (Reserva r in unRepoR.ListarReservas())
            {
                if ((r.EventoDeportivoId == unEvento.Id) && (r.EstadoAsistencia == Asistencia.Presente)) // filtro si la reserva se corresponde con el evento
                {           // creo una lista solo con las reservas que asistieron
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