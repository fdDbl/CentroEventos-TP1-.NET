namespace CentroEventos.Aplicacion;

public class PersonaModificacionValidador 
{
    public bool Validar(Persona p, IRepositorioPersona repo, out string msg)
    {
        msg = " ";
        Persona? p1 = repo.ListarPersonas().Find(persona => persona.Id == p.Id);
        if (p1 == null) msg += "No se encontro la persona";
        return msg == " ";
    }
}
