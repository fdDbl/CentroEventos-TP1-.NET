using System;

namespace CentroEventos.Aplicacion.validators;

public class EventoBajaValidador
{
    public bool ValidarEventoBaja (EventoDeportivo actividad,IRepositorioReserva repoReserva, out string msg)
    {
        msg="";
        if (repoReserva.ListarReservas()!=null) //Si la lista != null, quiere decir que tiene reservas asociadas
        {
            msg+= "No puede darse de baja el evento debido a que tiene reservas asociadas.\n";
        }
        return msg=="";
    }
}
