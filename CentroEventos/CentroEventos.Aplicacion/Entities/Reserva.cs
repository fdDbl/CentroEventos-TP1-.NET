namespace CentroEventos.Aplicacion;
public class Reserva
{
    public int Id { get; set; }
    public int PersonaId { get; set; }
    public int EventoDeportivoId { get; set; }
    public DateTime FechaAltaReserva { get; set; }
    public Asistencia EstadoAsistencia { get; set; }

    public Reserva () {}

    public Reserva (DateTime fechaDeReserva, Asistencia estadoAsistencia )
    {
        FechaAltaReserva=fechaDeReserva;
        EstadoAsistencia=estadoAsistencia;
    }
    public override string ToString()
    => $"ID de reserva: {Id} | ID de la persona responsable: {PersonaId} | ID de evento deportivo: {EventoDeportivoId} | Fecha de reserva: {FechaAltaReserva} | Estado de la asistencia: {EstadoAsistencia}";
}