namespace CentroEventos.Aplicacion;
public class EventoDeportivo{
    
    public int Id {get;set;}   
    public string? Nombre {get;set;}
    public DateTime DiasDisponibles{get;set;}
    public int CupoMaximo {get;set;}

    

public EventoDeportivo(int id, String? nombre, DateTime diasDisponibles, int cupoMaximo){
    Id=id;
    Nombre=nombre;
    DiasDisponibles= diasDisponibles;
    CupoMaximo = cupoMaximo;
    }
}
