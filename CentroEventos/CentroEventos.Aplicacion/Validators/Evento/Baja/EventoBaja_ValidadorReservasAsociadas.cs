namespace CentroEventos.Aplicacion;
public class EventoBaja_ValidadorReservasAsociadas
{
    public bool Validar(int eventoId, IRepositorioReserva repoReservas, out string msg) //
    {
        msg="";
        if (repoReservas.ContarReserva(eventoId)>0)
        {
            msg+= "No puede darse de baja el evento debido a que tiene reservas asociadas.\n";
        }
        return msg=="";
    }
}