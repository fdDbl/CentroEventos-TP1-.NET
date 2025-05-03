using System;

namespace CentroEventos.Aplicacion;

public class ActividadDeportiva
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public DateTime DiasDisponibles { get; set; }
    public int CupoMaximo { get; set; }


    public ActividadDeportiva(int id, String? nombre, DateTime diasDisponibles, int cupoMaximo)
    {
        Id = id;
        Nombre = nombre;
        DiasDisponibles = diasDisponibles;
        CupoMaximo = cupoMaximo;
    }
}