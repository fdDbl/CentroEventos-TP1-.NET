namespace  CentroEventos.Aplicacion;
public class Reserva
{
    public int Id {get;set;}
    public int IdPersona {get;set;}
    public int IdActDeportiva {get;set;}

    public TipoAsistencia EstadoAsistencia {get;set;}
    private DateTime _fechaDeReserva;
    public DateTime FechaDeReserva
    {
        get => _fechaDeReserva;
        set
        {
            if (value > DateTime.Now) this._fechaDeReserva=value;
            else throw new 
        }
    }

    public Reserva (int id, int idPersona,int idActDeportivo, DateTime fechaDeReserva, TipoAsistencia estadoAsistencia )
    {
        Id=id;
        IdPersona=idPersona;
        IdActDeportiva=idActDeportivo;
        FechaDeReserva=fechaDeReserva;
        EstadoAsistencia=estadoAsistencia;
    }


    
    
}