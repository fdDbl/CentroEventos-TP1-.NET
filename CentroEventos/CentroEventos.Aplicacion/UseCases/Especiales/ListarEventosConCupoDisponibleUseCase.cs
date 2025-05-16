namespace CentroEventos.Aplicacion.UseCases.Actividad;

public class ListarEventosConCupoDisponibleUseCase(IRepositorioEventoDeportivo repoEventos,IRepositorioReserva repoReservas)
{
    public List<EventoDeportivo> Ejecutar () {
        List<EventoDeportivo> cuposDisp = new List<EventoDeportivo>();
        foreach (EventoDeportivo e in repoEventos.ListarEventosFuturos()) { // hago una lista de mis eventos futuros
            if (repoReservas.ContarReserva(e.Id) < e.CupoMaximo) { // por cada evento evaluo si hay cupos disponibles
                cuposDisp.Add(e); // si los hay agrego
            }
        }
        return cuposDisp; // devuelvo lista con eventos con cupos disponibles
    }
}