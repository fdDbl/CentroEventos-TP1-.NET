namespace CentroEventos.Aplicacion;

public class AltaPersonaUseCase(IRepositorioPersona repo,PersonaValidador validador) 
 //agrege el repo actividad para verificar q no este en la actividad
{  
    public void Ejecutar(Persona persona)
    {
        if (!validador.ValidarPersona(persona,repo,out string msg)){
            throw new ValidacionException(msg);
        }
        repo.AltaPersona(persona);
    }
}