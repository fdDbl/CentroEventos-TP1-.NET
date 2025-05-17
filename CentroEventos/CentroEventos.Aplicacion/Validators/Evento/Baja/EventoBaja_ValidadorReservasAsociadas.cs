namespace CentroEventos.Aplicacion;
public class EventoBaja_ValidadorReservasAsociadas (IRepositorioReserva repoReservas)
{
    public bool Validar(EventoDeportivo evento, IRepositorioReserva repoReservas, out string msg)
    {
        msg="";
        if (repoReservas.ContarReserva(evento.Id)>0)
        {
            msg+= "No puede darse de baja el evento debido a que tiene reservas asociadas.\n";
        }
        return msg=="";
    }
}