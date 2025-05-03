namespace  CentroEventos.Aplicacion;
public class Reserva
{
    public int Id {get;set;}
    public int IdPersona {get;set;}
    public int IdActDeportiva {get;set;}

    public DateTime FechaDeReserva{get;set;}
    public Asistencia EstadoAsistencia {get;set;}


    public Reserva (int id, int idPersona,int idActDeportivo, DateTime fechaDeReserva, Asistencia estadoAsistencia )
    {
        Id=id;
        IdPersona=idPersona;
        IdActDeportiva=idActDeportivo;
        FechaDeReserva=fechaDeReserva;
        EstadoAsistencia=estadoAsistencia;
    }

    public override string ToString()
    => $"ID de reserva {Id}, ID de la persona {IdPersona}, ID de actividad deportiva {IdActDeportiva}, fecha de reserva: {FechaDeReserva}, estado de la asistencia: {EstadoAsistencia}";

    
    
}