namespace CentroEventos.Aplicacion;

public class ModificarPersonaUseCase(IServicioAutorizacion auth, IRepositorioPersona repo, PersonaModificacionValidador validador)
{
    public void Ejecutar(Persona persona, int unId)
    {
        if (!auth.PoseeElPermiso(unId, Permiso.UsuarioModificacion))
            throw new FalloAutorizacionException("No posee el permiso para modificar una Persona");
        if (!validador.Validar(persona, repo, out string msg))
            throw new ValidacionException(msg);
        repo.ModificarPersona(persona); 
        
    }
}