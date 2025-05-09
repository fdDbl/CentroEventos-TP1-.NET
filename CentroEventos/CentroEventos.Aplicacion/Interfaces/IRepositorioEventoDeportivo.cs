namespace CentroEventos.Aplicacion;

public interface IRepositorioActividad
{
    void AltaActividad(EventoDeportivo actividad);
    void BajaActividad(int id);
    void ModificarActividad(EventoDeportivo actividad);
    List<EventoDeportivo> ListarActividades();
}