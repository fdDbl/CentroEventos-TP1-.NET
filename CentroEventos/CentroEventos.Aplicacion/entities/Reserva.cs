namespace  CentroEventos.Aplicacion;
public class Reserva
{
    static int s_id = 0;
    public static int Id {
        get => s_id;
        
        set => s_id = value +1; // preguntar como debe ser gestionado por el repositorio
        }
    public int PersonaId {get;set;}
    public int EventoDeportivoId {get;set;}
    public DateTime FechaAltaReserva{get;set;}
    public Asistencia EstadoAsistencia {get;set;}


    public Reserva (/*int id,*/ int idPersona,int idActDeportivo, DateTime fechaDeReserva, Asistencia estadoAsistencia )
    {
      //  Id=id;
        PersonaId=idPersona;
        EventoDeportivoId=idActDeportivo;
        FechaAltaReserva=fechaDeReserva;
        EstadoAsistencia=estadoAsistencia;
    }

    public override string ToString()
    => $"ID de reserva {Id}, ID de la persona responsable {PersonaId}, ID de actividad deportiva {EventoDeportivoId}, fecha de reserva: {FechaAltaReserva}, estado de la asistencia: {EstadoAsistencia}";

    
    
}