namespace CentroEventos.Aplicacion;

public class EventoAltaValidadorFecha
{
    public bool ValidarEventoAltaFecha(EventoDeportivo actividad, out string msg)
    {
        msg = "";
        bool aux = true;
        if (actividad.FechaHoraInicio < DateTime.Now)
        {
            msg += "La fecha ingresada debe ser igual o posterior a la fecha .\n";
            aux = false;
        }
        return aux;
    }
}