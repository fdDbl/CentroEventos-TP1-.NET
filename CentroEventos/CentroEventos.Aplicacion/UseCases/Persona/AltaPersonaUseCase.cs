

namespace CentroEventos.Aplicacion;

public class AltaPersonaUseCase(IRepositorioPersona repo,PersonaValidador validadorPersona,EmailValidador validarEmail,DniValidador validarDni ) 
 //agrege el repo actividad para verificar q no este en la actividad
{  
    public void Ejecutar(Persona persona)
    {
        string msg;
        if (!validadorPersona.ValidarPersona(persona, repo, out  msg))
            throw new ValidacionException(msg);
        if (!validarEmail.ValidarEmail(persona.Email, repo, out msg))
            throw new DuplicadoException(msg);
        if (!validarDni.Validar(persona.Dni, repo, out msg))
            throw new DuplicadoException(msg);

        repo.AltaPersona(persona);
    }
}

