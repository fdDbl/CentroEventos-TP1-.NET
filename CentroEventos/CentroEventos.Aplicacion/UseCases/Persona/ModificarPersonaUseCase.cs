namespace CentroEventos.Aplicacion;

public class ModificarPersonaUseCase(IRepositorioPersona repo, PersonaModificacionValidador validador)
{
    public void Ejecutar(Persona persona, Persona personaModificada) {
        if (!validador.validar(persona, repo, out string msg)) {
            repo.ModificarPersona(persona, personaModificada); // 
        }
    }
}