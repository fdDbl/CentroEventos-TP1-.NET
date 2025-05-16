using CentroEventos.Aplicacion;
using CentroEventos.Repositorios;


var servicioAutorizacion = new ServicioAutorizacionProvisorio();

var validadorReservaAlta1 = new ReservaAltaExistencias();
var validadorReservaAlta2 = new ReservaAltaDuplicado();
var validadorReservaAlta3 = new ReservaAltaCupoDisponible();
var validadorReservaBaja = new ReservaBajaExistencia();
var validadorReservaMod = new ReservaModificarValidador_Existentes();

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
    altaEventoDeportivo.Ejecutar(new EventoDeportivo("Voley","Para mayores de 13 años.", new DateTime(2025,05,17),5,12),1);
    
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

//Console.ReadKey();