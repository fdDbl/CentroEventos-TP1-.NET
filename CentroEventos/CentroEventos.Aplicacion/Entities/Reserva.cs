namespace CentroEventos.Aplicacion;
public class Reserva
{
    public int Id { get; set; }
    public int PersonaId {get;set;}
    public int EventoDeportivoId {get;set;}
    public DateTime FechaAltaReserva{get;set;}
    public Asistencia EstadoAsistencia {get;set;}

    public Reserva () {}

    public Reserva (int idPersona,int idActDeportivo, DateTime fechaDeReserva, Asistencia estadoAsistencia )
    {
        PersonaId=idPersona;
        EventoDeportivoId=idActDeportivo;
        FechaAltaReserva=fechaDeReserva;
        EstadoAsistencia=estadoAsistencia;
    }

    public override string ToString()
    => $"ID de reserva {Id}, ID de la persona responsable {PersonaId}, ID de actividad deportiva {EventoDeportivoId}, fecha de reserva: {FechaAltaReserva}, estado de la asistencia: {EstadoAsistencia}";

    
    
}