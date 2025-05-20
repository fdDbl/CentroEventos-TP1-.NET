namespace CentroEventos.Aplicacion;

public class EventoModificadorValidadorFecha
{
    public bool ValidarEventoModificacionFecha (EventoDeportivo unEvento, IRepositorioEventoDeportivo unRepo, out string msg)
    {
        msg = "";
        if (unEvento.FechaHoraInicio < DateTime.Now)
        {
            msg += "No puede modificarse un evento anterior a la fecha de hoy.\n";
        }
        return msg == "";
    }
}
 