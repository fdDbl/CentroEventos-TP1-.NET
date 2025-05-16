namespace CentroEventos.Aplicacion;

public class ModificarPersonaUseCase(IRepositorioPersona repo)
{
    public void Ejecutar (Persona persona,Persona personaModificada ){
        repo.ModificarPersona(persona,personaModificada); // 
    }
}