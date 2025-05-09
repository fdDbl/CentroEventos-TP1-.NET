namespace CentroEventos.Aplicacion;
public class ActividadValidador {
    public bool ValidarActividad(EventoDeportivo actividad,IRepositorioPersona unRepo, out string msg) {
        msg = "";
        if(string.IsNullOrWhiteSpace(actividad.Nombre)) {
            msg = "El nombre no puede estar vacío.\n";
        }
        
        if(actividad.CupoMaximo <= 0) {
            msg += "El Cupo maximo debe que ser mayor que 0.\n";
        }

        if (actividad.FechaHoraInicio < DateTime.Now) {
            msg += "La fecha ingresada debe ser igual o posterior a la fecha .\n";
        }

        if (actividad.DuracionHoras == 0) {
            msg += "La actividad debe tener una duracion mayor a 0.\n";
        }

        if (unRepo.obtenerPersona(actividad.ResponsableId) == null)
        {
            msg += "Responsable no existente.\n";
        }
        return msg == "";
    }
}