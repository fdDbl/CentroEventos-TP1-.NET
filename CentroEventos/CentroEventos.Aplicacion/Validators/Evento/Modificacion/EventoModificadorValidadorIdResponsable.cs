namespace CentroEventos.Aplicacion;

public class EventoModificadorValidadorIdResponsable
{
    public bool ValidarEventoModificacionIdResponsable (EventoDeportivo unEvento, IRepositorioPersona unRepo, out string msg)
    {
        msg = "";
        if (unRepo.ObtenerPersona(unEvento.ResponsableId) == null)
        {
            msg += "No existe la persona ingresada.\n";
        }
        return msg == "";
    }
}