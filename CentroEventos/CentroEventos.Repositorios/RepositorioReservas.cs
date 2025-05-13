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
        Reserva rBaja = BuscarReservaPorID(idBaja);
    
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

    public List<Reserva> ListarReservas () {
        using StreamReader sr = new StreamReader(_nombreArch);
        List <Reserva> listaR = new List<Reserva>(); 
        while (!sr.EndOfStream) {
            Reserva reserva = new Reserva();
            reserva.Id=int.Parse(sr.ReadLine()?? "");
            reserva.PersonaId= int.Parse(sr.ReadLine()?? "");
            reserva.FechaAltaReserva=DateTime.Parse(sr.ReadLine()?? "");
           // reserva.EstadoAsistencia= sr.ReadLine()?? "";  <---- COMO HAGO CON UN ENUM
            listaR.Add(reserva);
        }
        return listaR;
    }

    public void ModificarReserva(Reserva unaRes) {
        using StreamWriter sw = new StreamWriter(_nombreArch,false);
        List <Reserva> listaRes = ListarReservas(); // crear metodo listarReservas
        foreach (Reserva r in listaRes) {
            if (BuscarReservaPorID(r.Id)) { // if (r.Id == unaRes.Id) CON EL METODO NOSE XQ NO COMPILA
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
