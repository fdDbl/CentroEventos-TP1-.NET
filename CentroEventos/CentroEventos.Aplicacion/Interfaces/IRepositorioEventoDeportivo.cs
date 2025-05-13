namespace CentroEventos.Aplicacion;

public interface IRepositorioEventoDeportivo
{
    void AltaActividad(EventoDeportivo actividad);
    void BajaActividad(int id);
    void ModificarActividad(EventoDeportivo actividad);
    List<EventoDeportivo> ListarActividades();
}