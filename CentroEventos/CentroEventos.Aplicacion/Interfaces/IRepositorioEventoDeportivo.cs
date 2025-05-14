namespace CentroEventos.Aplicacion;

public interface IRepositorioEventoDeportivo
{
    void EventoAlta(EventoDeportivo actividad);
    void EventoBaja(int id);
    void EventoModificacion(EventoDeportivo actividad);
    EventoDeportivo? ObtenerEvento(int id); //Busca un evento por id
    List<EventoDeportivo> ListarEventosConCupoDisponible();
    List<EventoDeportivo> ListarEventos();

}