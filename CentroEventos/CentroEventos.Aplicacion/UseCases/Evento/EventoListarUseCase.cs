namespace CentroEventos.Aplicacion;

public class EventoListarUseCase(IRepositorioEventoDeportivo repo)
{
    public List<EventoDeportivo> Ejecutar()
    {
        return repo.ListarEventos();
    }
}