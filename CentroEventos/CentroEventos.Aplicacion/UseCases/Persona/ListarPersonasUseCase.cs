namespace CentroEventos.Aplicacion;

public class ListarPersonasUseCase(IRepositorioPersona repo)
{
    public List<Persona> Ejecutar()
    {
        return repo.ListarPersonas();
    }
}