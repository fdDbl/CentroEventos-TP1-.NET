

namespace CentroEventos.Aplicacion.Validators.Persona;

public class PersonaBajaValidador
{
    public bool Validar(int id, IRepositorioEventoDeportivo repo, out string msg)
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
<<<<<<< HEAD
        return msg ==""; 
=======
        return msg == "";
>>>>>>> 1ae640718a6e2dd2f8b1c937d878eb6aee4aadeb
    }
}
