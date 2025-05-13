namespace CentroEventos.Repositorios;
using CentroEventos.Aplicacion;
public class RepositorioReservas : IRepositorioReserva
{
    private readonly string _nombreArch = "Reservas.txt";
    private readonly string _nombreArchID = "IDReservaActual.txt";
    public void AltaReserva(Reserva reserva)
    {
        using var sr = new StreamReader(_nombreArchID);
        int idAct = int.Parse(sr.ReadLine());
        reserva.Id = idAct;
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(reserva.Id);
        sw.WriteLine(reserva.PersonaId);
        sw.WriteLine(reserva.FechaAltaReserva);
        sw.WriteLine(reserva.EstadoAsistencia);
        
        using var swID = new StreamWriter(_nombreArchID,false);
        swID.WriteLine(idAct+1);
    }
    public void BajaReserva(int idBaja)
    {
        Reserva? rBaja = BuscarReservaPorID(idBaja);
        List<Reserva> reservas = ListarReservas();
        if (rBaja != null)
        {
            reservas.Remove(rBaja);
            SobreEscribirReservas(reservas);
        }
        else
            RepositorioException()
    }
    private Reserva BuscarReservaPorID(int id)
    {
        foreach(Reserva r in ListarReservas())
        {
            if(r.Id == id)
            {
                return r;
            }
        }
        throw new RepositorioException("El expediente buscado no existe.");
    }

    public void ModificarReserva(Reserva unaRes) {
        using StreamWriter sw = new StreamWriter(_nombreArch,false);
        List <Reserva> listaRes = new List<Reserva>();
        foreach (Reserva r in listaRes) {
            if (r.Id == unaRes.Id) {
                sw.WriteLine(unaRes.PersonaId);
                sw.WriteLine(unaRes.FechaAltaReserva);
                sw.WriteLine(unaRes.EstadoAsistencia);
            }
            sw.WriteLine(r.Id);
            sw.WriteLine(r.PersonaId);
            sw.WriteLine(r.FechaAltaReserva);
            sw.WriteLine(r.EstadoAsistencia);
        }
    }

}
