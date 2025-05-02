using System;

namespace CentroEventos.Aplicacion;
public class ActividadDeportiva{
    
    public int Id {get;set;}
    
    private string _nombre;
    public required string? Nombre {

        get{
            return _nombre;
        }

        set {
            if (value != null)this.Nombre=value;
            else
                throw new ArgumentException ("ES OBLIGATORIO INGRESAR UN NOMBRE");
        }


    }
    public DateTime DiasDisponibles{get;set;}
    private int _CupoMaximo;
    public int cupoMaximo {
        get {
            return _CupoMaximo;
        }
        set {                
            if (value > 0){
                    _CupoMaximo= value;
            }  
            else
                {
                    throw  new ArgumentException ("EL CUPO MAXIMO DEBE SER MAYOR A 0");
                }
        }

    }

public  ActividadDeportiva(int id, String? nombre, DateTime diasDisponibles, int cupoMaximo){
    Id=id;
    Nombre=nombre;
    DiasDisponibles= diasDisponibles;
    _CupoMaximo = cupoMaximo;
}

}