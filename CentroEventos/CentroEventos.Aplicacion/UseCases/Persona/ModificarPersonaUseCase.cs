namespace CentroEventos.Aplicacion;

public class ModificarPersonaUseCase(IRepositorioPersona repo)
{
    public void Ejecutar (Persona persona ){
        repo.ModificarPersona(persona);
    }
}