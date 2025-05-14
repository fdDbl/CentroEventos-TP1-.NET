namespace CentroEventos.Repositorios;

using Aplicacion;

public class RepositorioReserva : IRepositorioReserva
{
    private readonly string _nombreArch = "Reservas.txt";

    public void AltaReserva(Reserva reserva)
    {
        var idAct = RepositorioIdReserva.NextIdActual();
        reserva.Id = idAct;
        using (var sw = new StreamWriter(_nombreArch, true))
        {
            sw.WriteLine($"{reserva.Id} | {reserva.PersonaId} | {reserva.EventoDeportivoId} | {reserva.FechaAltaReserva:yyyy-MM-dd HH:mm:ss} | {reserva.EstadoAsistencia}");
        }
    }

    public void BajaReserva(int idBaja)
    {
        try
        {
            var rBaja = BuscarReservaPorId(idBaja);
            var reservas = ListarReservas();
            reservas.Remove(rBaja);
            SobreEscribirReservas(reservas);
        }
        catch (RepositorioException e)
        {
            throw new RepositorioException($"Error al dar de baja la reserva: {e.Message}");
        }
    }

    private void SobreEscribirReservas(List<Reserva> lista)
    {
        using StreamWriter sw = new StreamWriter(_nombreArch, false); //false para sobreescribir
        foreach (Reserva r in lista)
        {
            sw.WriteLine($"{r.Id} | {r.PersonaId} | {r.EventoDeportivoId} | {r.FechaAltaReserva:yyyy-MM-dd HH:mm:ss} | {r.EstadoAsistencia}");
            //sobreescribo el archivo
        }
    }

    private Reserva BuscarReservaPorId(int id)
    {
        foreach (Reserva r in ListarReservas())
        {
            if (r.Id == id)
                return r;
        }
        throw new RepositorioException("El expediente buscado no existe.");
    }

    public List<Reserva> ListarReservas()
    {
        var listaR = new List<Reserva>();
        if (!File.Exists(_nombreArch))
            return listaR;
        
        using StreamReader sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            Reserva reservaNew = new Reserva();
            string st = sr.ReadLine() ?? "";
            string[] lSplitted = st.Split(" | ");
            reservaNew.Id = int.Parse(lSplitted[0]);
            reservaNew.PersonaId = int.Parse(lSplitted[1]);
            reservaNew.FechaAltaReserva = DateTime.Parse(lSplitted[2]);
            reservaNew.EstadoAsistencia = (Asistencia)Enum.Parse(typeof(Asistencia), lSplitted[3]);
            listaR.Add(reservaNew);
        }

        return listaR;
    }

    public void ModificarReserva(Reserva unaRes)
    {
        try
        {
            var rMod = BuscarReservaPorId(unaRes.Id);
            rMod.Id = unaRes.Id;
            rMod.PersonaId = unaRes.PersonaId;
            rMod.EventoDeportivoId = unaRes.EventoDeportivoId;
            rMod.FechaAltaReserva = unaRes.FechaAltaReserva;
            rMod.EstadoAsistencia = unaRes.EstadoAsistencia;

            var reservas = ListarReservas();
            SobreEscribirReservas(reservas);
        }
        catch (RepositorioException e)
        {
            throw new RepositorioException($"Error al intentar modificar reserva: {e.Message}");
        }
    }
}