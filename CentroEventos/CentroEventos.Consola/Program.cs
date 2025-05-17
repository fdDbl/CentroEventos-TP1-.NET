using System.Linq.Expressions;
using CentroEventos.Aplicacion;
using CentroEventos.Aplicacion.Validators.Persona;
using CentroEventos.Repositorios;

// Servicio de autorización
var servicioAutorizacion = new ServicioAutorizacionProvisorio();

// Validadores de Reserva
var validadorReservaAlta1 = new ReservaValidador_AltaExistencias();
var validadorReservaAlta2 = new ReservaValidador_AltaDuplicado();
var validadorReservaAlta3 = new ReservaAlta_CupoDisponible();
var validadorReservaBaja = new ReservaValidador_BajaExistencia();
var validadorReservaMod = new ReservaValidador_ModificarExistentes();



// Repositorios para inyectar
IRepositorioPersona repositorioPersona = new RepositorioPersona();
IRepositorioReserva repositorioReserva = new RepositorioReserva();
IRepositorioEventoDeportivo repositorioEventoDeportivo = new RepositorioEventoDeportivo();

// Casos de uso de EventoDeportivo
var altaEventoDeportivo = new EventoAltaUseCase(servicioAutorizacion,repositorioEventoDeportivo,repositorioPersona,new EventoAltaValidador());
var bajaEventoDeportivo = new EventoBajaUseCase(servicioAutorizacion,repositorioEventoDeportivo,repositorioReserva,new EventoBajaValidador());
var modificarEventoDeportivo = new EventoModificacionUseCase(servicioAutorizacion,repositorioEventoDeportivo,new EventoModificadorValidador());
var listarEventosDeportivos = new EventoListarUseCase(repositorioEventoDeportivo);

// Casos de uso de Reserva
var altaReserva = new ReservaAltaUseCase(servicioAutorizacion,repositorioReserva,repositorioEventoDeportivo,repositorioPersona,validadorReservaAlta1,validadorReservaAlta2,validadorReservaAlta3);
var bajaReserva = new ReservaBajaUseCase(servicioAutorizacion,repositorioReserva,validadorReservaBaja);
var modificarReserva = new ReservaModificarUseCase(servicioAutorizacion,repositorioReserva,repositorioEventoDeportivo,repositorioPersona,validadorReservaMod);
var listarReservas = new ReservaListarUseCase(repositorioReserva);

//Casos de uso Persona
var altaPersona = new AltaPersonaUseCase(repositorioPersona, new PersonaValidador(), new EmailValidador(),new DniValidador());
var bajaPersona = new BajaPersonaUseCase(repositorioPersona, repositorioEventoDeportivo, new PersonaBajaValidador());
var modificarPersona = new ModificarPersonaUseCase(repositorioPersona, new PersonaModificacionValidador());
var ListarPersonas = new ListarPersonasUseCase(repositorioPersona);
// Programa principal
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
try
{
    Persona per = new Persona("45297418", "FACUNDO", "Villca", 221, "facuVillca@hotmail.com");
    altaPersona.Ejecutar(per);

}
catch (Exception e)
{
    Console.WriteLine($"{e.GetType()}: {e.Message}");
}
try
{
    var listaPersonas = ListarPersonas.Ejecutar();
    foreach (Persona p in listaPersonas)
    {
        Console.WriteLine(p.ToString());
    }
}
catch (Exception e)
{
    Console.WriteLine($"{e.GetType()} : {e.Message}");
}
