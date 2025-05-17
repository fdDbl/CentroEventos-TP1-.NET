namespace CentroEventos.Aplicacion;
public class EventoAltaValidadorCupoMaximo
{
    public bool ValidarEventoAltaCupoMaximo(EventoDeportivo actividad, IRepositorioPersona unRepo, out string msg)
    {
        msg = ""; // anotando a ver si me pushea bien
        bool aux = true;
        if (actividad.CupoMaximo <= 0)
        {
            msg += "El Cupo maximo debe que ser mayor que 0.\n";
            aux = false;
        }
        return aux;
    }
}