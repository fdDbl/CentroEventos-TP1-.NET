using System;

namespace CentroEventos.Aplicacion.Validators.Persona;

public class PersonaBajaValidador
{
    public bool validar(int id, IRepositorioEventoDeportivo repo)
    {
        foreach (EventoDeportivo e in repo.ListarEventos())
        {
            if (e.ResponsableId == id)
            {
                return false;
            }
        }
        return true; 
    }
}
