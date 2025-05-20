namespace CentroEventos.Aplicacion;
public class EventoAltaValidadorDesc {
    public bool ValidarEventoAltaDesc(EventoDeportivo actividad, out string msg) {
        msg = "";
        bool aux = true;
        if (string.IsNullOrWhiteSpace(actividad.Nombre))
        {
            msg = "La descripcion no puede estar vacía.\n";
            aux = false;
        }
        return aux;
    }
}