namespace CentroEventos.Aplicacion;
public class EventoAltaValidadorNombre {
    public bool ValidarEventoAltaNombre(EventoDeportivo actividad,IRepositorioPersona unRepo, out string msg) {
        msg = "";
        bool aux = true;
        if (string.IsNullOrWhiteSpace(actividad.Nombre))
        {
            msg = "El nombre no puede estar vacío.\n";
            aux = false;
        }
        
      /*  if (actividad.FechaHoraInicio < DateTime.Now) {
            msg += "La fecha ingresada debe ser igual o posterior a la fecha .\n";
        }

        if (actividad.DuracionHoras == 0) {
            msg += "La actividad debe tener una duracion mayor a 0.\n";
        }
        
        if (unRepo.ObtenerPersona(actividad.ResponsableId) == null) //busca la persona por id
        {
            msg += "Responsable no existente.\n";
        }*/ // lo comento para luego pasarlo a validadores independientes
        return aux;
    }
}