namespace CentroEventos.Aplicacion;

public class ReservaListarUseCase(IRepositorioReserva repoR)
{
    public void Ejecutar()
    {
        repoR.ListarReservas();
    }
}