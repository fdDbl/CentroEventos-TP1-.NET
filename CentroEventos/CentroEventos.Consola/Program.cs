using CentroEventos.Aplicacion;
using CentroEventos.Repositorios;


var servicioAutorizacion = new ServicioAutorizacionProvisorio();

var validadorReservaAlta1 = new ReservaValidador_AltaExistencias();
var validadorReservaAlta2 = new ReservaValidador_AltaDuplicado();
var validadorReservaAlta3 = new ReservaAlta_CupoDisponible();
var validadorReservaBaja = new ReservaValidador_BajaExistencia();
var validadorReservaMod = new ReservaValidador_ModificarExistentes();

IRepositorioPersona repositorioPersona = new RepositorioPersona();
IRepositorioReserva repositorioReserva = new RepositorioReserva();
IRepositorioEventoDeportivo repositorioEventoDeportivo = new RepositorioEventoDeportivo();

var altaEventoDeportivo = new EventoAltaUseCase(servicioAutorizacion,repositorioEventoDeportivo,repositorioPersona,new EventoAltaValidador());
var bajaEventoDeportivo = new EventoBajaUseCase(servicioAutorizacion,repositorioEventoDeportivo,repositorioReserva,new EventoBajaValidador());
var modificarEventoDeportivo = new EventoModificacionUseCase(servicioAutorizacion,repositorioEventoDeportivo,new EventoModificadorValidador());
var listarEventosDeportivos = new EventoListarUseCase(repositorioEventoDeportivo);

var altaReserva = new ReservaAltaUseCase(servicioAutorizacion,repositorioReserva,repositorioEventoDeportivo,repositorioPersona,validadorReservaAlta1,validadorReservaAlta2,validadorReservaAlta3);
var bajaReserva = new ReservaBajaUseCase(servicioAutorizacion,repositorioReserva,validadorReservaBaja);
var modificarReserva = new ReservaModificarUseCase(servicioAutorizacion,repositorioReserva,repositorioEventoDeportivo,repositorioPersona,validadorReservaMod);
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
    Console.WriteLine($"{e.GetType()}: {e.Message}");
}

Console.ReadKey();