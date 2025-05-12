using System;
using CentroEventos.Aplicacion;
    ///facu
namespace CentroEventos.Repositorios;

public class RepositorioPersona:IRepositorioPersona
{
    readonly string _nombreArch = "RepositoriosPersonas.txt";
    readonly string _nombreIdArch = "RepositoriosIdPersonas.txt";

    public void AltaActividad (Persona per )
    {
      if (!BuscarPersonaDni(per.Dni))
      {

      }
        
    }
    
    private bool BuscarPersonaDni (String? dni)
    {
        using 
    }

}