namespace CentroEventos.Aplicacion;

public class ModificarPersonaUseCase(IServicioAutorizacion auth, IRepositorioPersona repo, PersonaModificacionValidador validador)
{
    public void Ejecutar(Persona persona, Persona personaModificada, int unId)
    {
        if (!auth.PoseeElPermiso(unId, Permiso.UsuarioModificacion))
            throw new FalloAutorizacionException("No posee el permiso para modificar una Persona");
        if (!validador.validar(persona, repo, out string msg))
            throw new ValidacionException(msg);
        repo.ModificarPersona(persona, personaModificada); 
        
    }
}