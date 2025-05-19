using CentroEventos.Aplicacion;
using CentroEventos.Aplicacion.Validators.Persona;
using CentroEventos.Consola;
using CentroEventos.Repositorios;

// Servicio de autorización
var servicioAutorizacion = new ServicioAutorizacionProvisorio();

// Validadores de Reserva
var validadorReservaAlta1 = new ReservaValidadorAltaExistencias();
var validadorReservaAlta2 = new ReservaValidadorAltaDuplicado();
var validadorReservaAlta3 = new ReservaAltaCupoDisponible();
var validadorReservaBaja = new ReservaValidadorBajaExistencia();
var validadorReservaMod = new ReservaValidadorModificarExistentes();

// Validadores de EventoDeportivo
var validadorEventoAlta1 = new EventoAltaValidadorNombre();
var validadorEventoAlta2 = new EventoAltaValidadorCupoMaximo();
var validadorEventoAlta3 = new EventoAltaValidadorDesc();
var validadorEventoAlta4 = new EventoAltaValidadorDuracion();
var validadorEventoAlta5 = new EventoAltaValidadorFecha();
var validadorEventoAlta6 = new EventoAltaValidadorResponsable();
var validadorEventoBaja = new EventoBajaValidadorReservasAsociadas();
var validadorEventoMod1 = new EventoModificadorValidadorFecha();
var validadorEventoMod2 = new EventoModificadorValidadorCupo();
var validadorEventoMod3 = new EventoModificadorValidadorIdResponsable();


// Validadores de Persona
var validadorPersonaAlta1 = new PersonaValidador();
var validadorPersonaAlta2 = new EmailValidador();
var validadorPersonaAlta3 = new DniValidador();
var validadorPersonaBaja = new PersonaBajaValidador();
var validadorPersonaMod = new PersonaModificacionValidador();

// Repositorios para inyectar
IRepositorioPersona repositorioPersona = new RepositorioPersona();
IRepositorioReserva repositorioReserva = new RepositorioReserva();
IRepositorioEventoDeportivo repositorioEventoDeportivo = new RepositorioEventoDeportivo();

// Casos de uso de EventoDeportivo
var altaEventoDeportivo = new EventoAltaUseCase(servicioAutorizacion,repositorioEventoDeportivo,repositorioPersona,validadorEventoAlta1,validadorEventoAlta2,validadorEventoAlta5,validadorEventoAlta6,validadorEventoAlta3,validadorEventoAlta4);
var bajaEventoDeportivo = new EventoBajaUseCase(servicioAutorizacion,repositorioEventoDeportivo,repositorioReserva,validadorEventoBaja);
var modificarEventoDeportivo = new EventoModificacionUseCase(servicioAutorizacion,repositorioEventoDeportivo,repositorioReserva,repositorioPersona,validadorEventoMod1,validadorEventoMod2,validadorEventoMod3);
var listarEventosDeportivos = new EventoListarUseCase(repositorioEventoDeportivo);

// Casos de uso de Reserva
var altaReserva = new ReservaAltaUseCase(servicioAutorizacion,repositorioReserva,repositorioEventoDeportivo,repositorioPersona,validadorReservaAlta1,validadorReservaAlta2,validadorReservaAlta3);
var bajaReserva = new ReservaBajaUseCase(servicioAutorizacion,repositorioReserva,validadorReservaBaja);
var modificarReserva = new ReservaModificarUseCase(servicioAutorizacion,repositorioReserva,repositorioEventoDeportivo,repositorioPersona,validadorReservaMod);
var listarReservas = new ReservaListarUseCase(repositorioReserva);

//Casos de uso Persona
var altaPersona = new AltaPersonaUseCase(servicioAutorizacion, repositorioPersona, validadorPersonaAlta1, validadorPersonaAlta2, validadorPersonaAlta3);
var bajaPersona = new BajaPersonaUseCase(servicioAutorizacion, repositorioPersona, repositorioEventoDeportivo, validadorPersonaBaja);
var modificarPersona = new ModificarPersonaUseCase(servicioAutorizacion, repositorioPersona, validadorPersonaMod);
var listarPersonas = new ListarPersonasUseCase(repositorioPersona);

// Programa principal
var selector = new Selector();

try
{
    // Alta de persona
    Persona persona = new Persona("45297418", "Facundo", "Villca", 221, "facuVillca@hotmail.com");
    altaPersona.Ejecutar(persona, 1);

    // Listar personas*/
    var listaPersonas = listarPersonas.Ejecutar();

    foreach (Persona p in listaPersonas)
    {
        Console.WriteLine(p);
    }

    // Alta de evento deportivo
    Console.WriteLine("Seleccione la persona responsable del nuevo evento deportivo:");
    selector.Personas(listarPersonas, out int indiceResponsable);
    int idResponsable = repositorioPersona.ObtenerIdPorIndice(indiceResponsable);

    EventoDeportivo evento = new EventoDeportivo(
        "Voley",
        "Deporte para mayores de 13 años.",
        new DateTime(2025, 5, 25),
        3,
        12,
        idResponsable
    );

    altaEventoDeportivo.Ejecutar(evento, 1);

    //Listar eventos deportivos
    var listaEventos = listarEventosDeportivos.Ejecutar();

    foreach (EventoDeportivo e in listaEventos)
    {
        Console.WriteLine(e);
    }

    //Modificación de evento
    Console.WriteLine("Seleccione el evento a modificar");
    selector.EventosDeportivos(listarEventosDeportivos, out int indiceEventoDeportivo);
    int idEventoDeportivo = repositorioEventoDeportivo.ObtenerIdPorIndice(indiceEventoDeportivo);

    EventoDeportivo? eventoModificado = repositorioEventoDeportivo.ObtenerEvento(idEventoDeportivo);
    if (eventoModificado != null)
    {
        eventoModificado.Nombre = "Fútbol";
        eventoModificado.FechaHoraInicio = new DateTime (2025, 5, 30);
        Console.WriteLine(eventoModificado.FechaHoraInicio);
        modificarEventoDeportivo.Ejecutar(eventoModificado, 1);
    }

    

    // Alta de reserva
    Console.WriteLine("Seleccione la persona a cargo de la reserva:");
    selector.Personas(listarPersonas, out int indicePersonaReserva);
    int idPersonaReserva = repositorioPersona.ObtenerIdPorIndice(indicePersonaReserva);

    Console.WriteLine("Seleccione el evento deportivo a reservar:");
    selector.EventosDeportivos(listarEventosDeportivos, out int indiceEventoReserva);
    int idEventoReserva = repositorioEventoDeportivo.ObtenerIdPorIndice(indiceEventoReserva);

    Reserva reserva = new Reserva(
        idPersonaReserva,
        idEventoReserva,
        DateTime.Now,
        Asistencia.Pendiente
    );

    altaReserva.Ejecutar(reserva, 1);

    // Listar reservas
    var listaReservas = listarReservas.Ejecutar();

    foreach (Reserva r in listaReservas)
    {
        Console.WriteLine(r);
    }

    // Modificación de reserva
    Console.WriteLine("Seleccione la reserva a modificar:");
    selector.Reservas(listarReservas, out int indiceReserva);
    int idReserva = repositorioReserva.ObtenerIdPorIndice(indiceReserva);

    Reserva reservaModificada = repositorioReserva.ObtenerReserva(idReserva);
    reservaModificada.EstadoAsistencia = Asistencia.Ausente;

    modificarReserva.Ejecutar(reservaModificada, 1);
}
catch (Exception e)
{
    Console.WriteLine(e);
}

Console.ReadKey();