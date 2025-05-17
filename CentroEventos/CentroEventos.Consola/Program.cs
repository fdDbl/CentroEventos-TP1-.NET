using CentroEventos.Aplicacion;
using CentroEventos.Aplicacion.Validators.Persona;
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
var validadorEventoBaja = new EventoBajaValidadorReservasAsociadas();
var validadorEventoMod = new EventoModificadorValidador();

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
var altaEventoDeportivo = new EventoAltaUseCase(servicioAutorizacion,repositorioEventoDeportivo,repositorioPersona,validadorEventoAlta1,validadorEventoAlta2);
var bajaEventoDeportivo = new EventoBajaUseCase(servicioAutorizacion,repositorioEventoDeportivo,repositorioReserva,validadorEventoBaja);
var modificarEventoDeportivo = new EventoModificacionUseCase(servicioAutorizacion,repositorioEventoDeportivo,validadorEventoMod);
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
try
{
    Persona per = new Persona("45297418", "FACUNDO", "Villca", 221, "facuVillca@hotmail.com");
    altaPersona.Ejecutar(per,1);
    var listaPersonas = listarPersonas.Ejecutar();
    foreach (Persona p in listaPersonas)
    {
       Console.WriteLine(p.ToString());
    }
}
catch (Exception e)
{
    Console.WriteLine(e);
}

try
{
     Console.WriteLine("Seleccione la persona responsable del nuevo evento deportivo:");
     var lista = listarPersonas.Ejecutar();
     for(int i = 1; i <= lista.Count; i++) {
         Console.WriteLine($"{i}) {lista[i-1]}");
     }
     int index = int.Parse(Console.ReadLine() ?? "-1") - 1;
     int unRespo = repositorioPersona.ObtenerIdPorIndice(index);
     
     EventoDeportivo ev = new EventoDeportivo("Voley", "Deporte para mayores de 13 años.", new DateTime(2025,5,16), 3, 12,unRespo);
     altaEventoDeportivo.Ejecutar(ev,1);
     var listaEventosDeportivos = listarEventosDeportivos.Ejecutar();
    foreach (EventoDeportivo e in listaEventosDeportivos)
    {
        Console.WriteLine(e);
    }
}
catch (Exception e)
{
    Console.WriteLine(e);
}

try
{
    int index;
    
    Console.WriteLine("Seleccione la persona a cargo de la reserva:");
    var listaP = listarPersonas.Ejecutar();
    for(int i = 1; i <= listaP.Count; i++) {
        Console.WriteLine($"{i}) {listaP[i-1]}");
    }
    index = int.Parse(Console.ReadLine() ?? "-1") - 1;
    int pId = repositorioPersona.ObtenerIdPorIndice(index);
    
    Console.WriteLine("Seleccione el evento deportivo a reservar:");
    var listaE = listarEventosDeportivos.Ejecutar();
    for(int i = 1; i <= listaE.Count; i++) {
        Console.WriteLine($"{i}) {listaE[i-1]}");
    }
    index = int.Parse(Console.ReadLine() ?? "-1") - 1;
    int eId = repositorioEventoDeportivo.ObtenerIdPorIndice(index);

    Reserva reserva = new Reserva(pId,eId,DateTime.Now,Asistencia.Pendiente);
    altaReserva.Ejecutar(reserva,1);
    var lista = listarReservas.Ejecutar();
    foreach (Reserva r in lista)
    {
        Console.Write(r.ToString());
    }
}
catch (Exception e)
{
    Console.WriteLine(e);
}

// HACER EN FORMA DE SELECTOR COMO ARRIBA:

// try { bajaPersona.Ejecutar(1,1); }
// catch (Exception e) { Console.WriteLine(e); }

// try { bajaEventoDeportivo.Ejecutar(3,1); }
// catch (Exception e) { Console.WriteLine(e); }

Console.ReadKey();