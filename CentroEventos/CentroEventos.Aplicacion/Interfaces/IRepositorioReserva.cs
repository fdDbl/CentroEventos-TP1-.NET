namespace CentroEventos.Aplicacion;

public interface IRepositorioReserva
{
    void AltaReserva(Reserva reserva);
    void BajaReserva(int id);
    void ModificarReserva(Reserva reserva);
    Reserva ObtenerReserva(int id);
    Reserva ObtenerReserva(int id, out int i);
    List<Reserva> ListarReservas();
    int ContarReserva(int EventoId);
}