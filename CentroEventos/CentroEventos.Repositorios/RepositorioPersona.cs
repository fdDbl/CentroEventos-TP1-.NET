using System;
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RepositorioPersona : IRepositorioPersona
{
    private readonly string _nombreArch = "RepositorioPersona.txt";
    private readonly string _nombreArchID = "RepositorioIdPersona.txt";

    public void AltaPersona(Persona persona){
        using StreamWriter sw = new StreamWriter(_nombreArch);
        sw.WriteLine(persona.Id);
        sw.WriteLine(persona.Dni);
        sw.WriteLine(persona.Nombre);
        sw.WriteLine(persona.Apellido);
        sw.WriteLine(persona.Telefono);
        sw.WriteLine(persona.Email);

    }
    public void BajaPersona(int id){
        using StreamReader st = new StreamReader (_nombreArch);

    }
    public void ModificarPersona(Persona persona){

    }
    public Persona obtenerPersona(int id){
        

    }
    public List<Persona> ListarPersonas(){

    }
}
