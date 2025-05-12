using System;
using System.Security.Cryptography;
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RepositorioPersona:IRepositorioPersona
{
    readonly string _nombreArch = "RepositoriosPersonas.txt";
    readonly string _nombreIdArch = "RepositoriosIdPersonas.txt";

    public void AltaActividad (EventoDeportivo eventoDeportivo)
    {
        using StreamReader st = new StreamReader (_nombreArch);
        using StreamWriter sw = new StreamWriter(_nombreArch);
        
    }
    
}