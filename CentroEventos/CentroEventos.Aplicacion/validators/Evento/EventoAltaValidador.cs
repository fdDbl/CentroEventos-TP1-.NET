namespace CentroEventos.Aplicacion;
public class EventoAltaValidador {
    public bool ValidarEventoAlta(EventoDeportivo actividad,IRepositorioPersona unRepo, out string msg) {
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

<<<<<<< HEAD
        if (unRepo.ObtenerPersona(actividad.ResponsableId) == null) // crear obtenerPersona()
=======
        if (unRepo.ObtenerPersona(actividad.ResponsableId) == null) //busca la persona por id
>>>>>>> 2156dfe85613d3cde0d93cd178677a7109285f84
        {
            msg += "Responsable no existente.\n";
        }
        return msg == "";
    }
}