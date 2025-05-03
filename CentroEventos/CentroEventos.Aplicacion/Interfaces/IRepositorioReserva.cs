namespace CentroEventos.Aplicacion;

public interface IRepositorioReserva
{
    void AltaReserva(Reserva reserva);
    void BajaReserva(int id);
    void ModificarReserva(Reserva reserva);
    List<Reserva> ListarReservas();
}