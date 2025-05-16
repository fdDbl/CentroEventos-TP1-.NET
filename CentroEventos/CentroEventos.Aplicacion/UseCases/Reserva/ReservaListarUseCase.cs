namespace CentroEventos.Aplicacion;

public class ReservaListarUseCase(IRepositorioReserva repoR)
{
    public List<Reserva> Ejecutar()
    {
        return repoR.ListarReservas();
    }
}