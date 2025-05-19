using System.Runtime.InteropServices;

namespace CentroEventos.Aplicacion;

public class EventoAltaValidadorResponsable
{
    public bool ValidarEventoAltaResponsable(EventoDeportivo actividad,IRepositorioPersona unRepo, out string msg)
    {
        msg = "";
        if (unRepo.ObtenerPersona(actividad.ResponsableId) == null) //busca la persona por id
        {
            msg += "Responsable no existente.\n";
        }
        return msg == "";
    }
}