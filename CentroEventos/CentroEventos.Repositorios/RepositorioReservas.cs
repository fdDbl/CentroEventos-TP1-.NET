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
        using var sr = new StreamReader(_nombreArchID);
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(reserva.Id);
        sw.WriteLine(reserva.PersonaId);
        sw.WriteLine(reserva.FechaAltaReserva);
        sw.WriteLine(reserva.EstadoAsistencia);
        
        using var swID = new StreamWriter(_nombreArchID,false);
        swID.WriteLine(idAct+1);
    }
}
