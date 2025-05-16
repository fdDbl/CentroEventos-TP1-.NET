namespace CentroEventos.Aplicacion.UseCases.Actividad;

public class ListarAsistenciaAEventoUseCase (EventoDeportivo unEvento, IRepositorioReserva unRepoR, IRepositorioPersona per) {

    public List<Persona> Ejecutar() {
<<<<<<< HEAD
        var listaP = new List<Persona>();   
        return null;
=======
        var listaP = new List<Persona>();
        if (unEvento.FechaHoraInicio < DateTime.Now) // evaluo si el evento es pasado
        {
            var listaPresentes = new List<Reserva>();
            foreach (Reserva r in unRepoR.ListarReservas())
            {
                if ((r.EventoDeportivoId == unEvento.Id) && (r.EstadoAsistencia == Asistencia.Presente)) // filtro si la reserva se corresponde con el evento
                {           // creo una lista solo con las reservas que asistieron al evento determinado
                    listaPresentes.Add(r);
                }
            }
            foreach (Reserva r in listaPresentes) // una vez con mi lista de presentes
            {
                Persona? p = per.ObtenerPersona(r.PersonaId); // busco las personas en el repo
                if (p != null)
                {
                    listaP.Add(p); // agrego
                }
            }
        }
        return listaP; // devuelvo lista
>>>>>>> 2156dfe85613d3cde0d93cd178677a7109285f84
    }
}