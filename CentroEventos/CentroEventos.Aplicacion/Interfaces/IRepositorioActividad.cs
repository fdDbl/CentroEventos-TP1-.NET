namespace CentroEventos.Aplicacion;

public interface IRepositorioActividad
{
    void AltaActividad(ActividadDeportiva actividad);
    void BajaActividad(int id);
    void ModificarActividad(ActividadDeportiva actividad);
    List<ActividadDeportiva> ListarActividades();
}