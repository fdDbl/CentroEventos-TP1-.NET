namespace CentroEventos.Aplicacion;

public class EventoDeportivo
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechaHoraInicio { get; set; }
    public double DuracionHoras { get; set; }
    public int CupoMaximo { get; set; }
    public int ResponsableId { get; set; }

    public EventoDeportivo(String? nombre, string? unaDesc, DateTime unaFecha, double unaDuracion, int cupoMaximo)
    {
        Nombre = nombre;
        Descripcion = unaDesc;
        FechaHoraInicio = unaFecha;
        DuracionHoras = unaDuracion;
        CupoMaximo = cupoMaximo;
    }
    public EventoDeportivo() { }

    public override string ToString()
    {
        return "-----------------\n" + $"Evento ID: {Id}, nombre del evento: {Nombre}, descripcion de evento: {Descripcion}" + "\n" +$"Fecha de inicio de actividad: {FechaHoraInicio}, duracion del evento: {DuracionHoras}, cupo maximo: {CupoMaximo}, ID responsable del evento {ResponsableId} ";

    }
}
