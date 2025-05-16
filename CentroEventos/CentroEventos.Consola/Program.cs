using CentroEventos.Aplicacion;
using CentroEventos.Aplicacion.UseCases.Actividad;
using CentroEventos.Aplicacion.validators;
using CentroEventos.Repositorios;

var servicioAutorizacion = new ServicioAutorizacionProvisorio();

IRepositorioPersona repositorioPersona = new RepositorioPersona();
IRepositorioReserva repositorioReserva = new RepositorioReserva();
IRepositorioEventoDeportivo repositorioEventoDeportivo = new RepositorioEventoDeportivo();

var altaEventoDeportivo = new EventoAltaUseCase(servicioAutorizacion,repositorioEventoDeportivo,repositorioPersona,new EventoAltaValidador());
var bajaEventoDeportivo = new EventoBajaUseCase(servicioAutorizacion,repositorioEventoDeportivo,repositorioReserva,new EventoBajaValidador());
var modificarEventoDeportivo = new EventoModificacionUseCase(servicioAutorizacion,repositorioEventoDeportivo,new EventoModificadorValidador());
var listarEventosDeportivos = new EventoListarUseCase(repositorioEventoDeportivo);

var altaReserva = new ReservaAltaUseCase(servicioAutorizacion,repositorioReserva,repositorioEventoDeportivo,repositorioPersona,new ReservaAltaValidador());
var bajaReserva = new ReservaBajaUseCase(servicioAutorizacion,repositorioReserva,new ReservaBajaValidador());
var modificarReserva = new ReservaModificarUseCase(servicioAutorizacion,repositorioReserva,repositorioEventoDeportivo,repositorioPersona,new ReservaModificarValidador());
var listarReservas = new ReservaListarUseCase(repositorioReserva);

try
{
    altaEventoDeportivo.Ejecutar(new EventoDeportivo("Voley","Para mayores de 13 años.", new DateTime(2025,05,17),5,12,1),1);
    
    var listaReservas = listarReservas.Ejecutar();
    foreach (Reserva r in listaReservas)
    {
        Console.WriteLine(r.ToString());
    }
}
catch (Exception e)
{
    Console.WriteLine($"{e.GetType()}: {e.Message}");
}

Console.ReadKey();