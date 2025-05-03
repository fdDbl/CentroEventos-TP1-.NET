namespace CentroEventos.Aplicacion;

public class ActividadValidador
{
    public bool ValidarActividad(ActividadDeportiva actividad, out string msg)
    {
        msg = "";

        if (string.IsNullOrWhiteSpace(actividad.Nombre)) msg = "El nombre no puede estar vacío.";

        if (actividad.CupoMaximo <= 0) msg += "El Cupo maximo debe que ser mayor que 0.";

        // de donde sacamos fecha
        
        // TipoActividad y Responsable ??

        return msg == "";
    }
}