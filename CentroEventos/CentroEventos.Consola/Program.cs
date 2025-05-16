using CentroEventos.Aplicacion;
using CentroEventos.Repositorios;

ServicioAutorizacionProvisorio servicioAutorizacion = new ServicioAutorizacionProvisorio();

IRepositorioPersona repositorioPersona = new RepositorioPersona();
IRepositorioReserva repositorioReserva = new RepositorioReserva();
IRepositorioEventoDeportivo repositorioEventoDeportivo = new RepositorioEventoDeportivo();

var altaReserva = new ReservaAltaUseCase(servicioAutorizacion,repositorioReserva,repositorioEventoDeportivo,repositorioPersona,new ReservaAltaValidador());
var bajaReserva = new ReservaBajaUseCase(servicioAutorizacion,repositorioReserva,new ReservaBajaValidador());
var modificarReserva = new ReservaModificarUseCase(servicioAutorizacion,repositorioReserva,repositorioEventoDeportivo,repositorioPersona,new ReservaModificarValidador());
var listarReservas = new ReservaListarUseCase(repositorioReserva);

try
{
    var listaReservas = listarReservas.Ejecutar();
    foreach (Reserva r in listaReservas)
    {
        Console.WriteLine(r.ToString());
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.ReadKey();