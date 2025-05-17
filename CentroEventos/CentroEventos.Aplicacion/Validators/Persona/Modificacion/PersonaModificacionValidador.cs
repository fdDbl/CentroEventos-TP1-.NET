using System;

namespace CentroEventos.Aplicacion;

public class PersonaModificacionValidador 
{
    public bool validar(Persona P, IRepositorioPersona repo, out string msg)
    {
        msg = " ";
        Persona? p = repo.ListarPersonas().Find(Persona => Persona.Id == P.Id);
        if (p == null) msg = "No se encontro la persona";
        return P != null;
    }
    //deberia la persona Poseer El Permiso y validar que este en el la lista Personas
}
