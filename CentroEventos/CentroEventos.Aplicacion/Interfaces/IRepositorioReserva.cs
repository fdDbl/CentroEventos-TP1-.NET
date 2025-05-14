namespace CentroEventos.Aplicacion;

public interface IRepositorioReserva
{
    void AltaReserva(Reserva reserva);
    void BajaReserva(int id);
    void ModificarReserva(Reserva reserva);
    Reserva ObtenerReserva(int id);
    List<Reserva> ListarReservas();
}