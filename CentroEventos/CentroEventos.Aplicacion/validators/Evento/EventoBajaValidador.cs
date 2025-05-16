namespace CentroEventos.Aplicacion.validators;
public class EventoBajaValidador
{
    public bool ValidarEventoBaja (EventoDeportivo actividad,IRepositorioEventoDeportivo repoEvento,IRepositorioReserva repoReserva, out string msg)
    {
        msg="";
            if (repoReserva.ContarReserva(actividad.Id) > 0) //Si la lista != 0, quiere decir que tiene reservas asociadas
            {
               msg+= "No puede darse de baja el evento debido a que tiene reservas asociadas.\n";
            }
        if (repoEvento.ObtenerEvento(actividad.Id)==null) //Verifico si hay un evento con el id recibido como parámetro
        {
            msg+="No existe un evento con el id recibido.\n";
        }
        return msg=="";
    }
}
