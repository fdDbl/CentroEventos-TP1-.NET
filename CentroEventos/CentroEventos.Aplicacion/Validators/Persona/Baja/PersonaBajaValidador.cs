

namespace CentroEventos.Aplicacion.Validators.Persona;

public class PersonaBajaValidador
{
    public bool validar(int id, IRepositorioEventoDeportivo repo, out string msg)
    {
        msg = "";
        foreach (EventoDeportivo e in repo.ListarEventos())
        {
            if (e.ResponsableId == id)
            {
                msg += "La persona es responsable de un evento";
                break;
            }
        }
        return true; 
    }
}
