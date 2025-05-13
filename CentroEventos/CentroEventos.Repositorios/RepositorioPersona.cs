using System;
//Villca
using CentroEventos.Aplicacion;
namespace CentroEventos.Repositorios;

public class RepositorioPersona : IRepositorioPersona
{
    private readonly string _nombreArch = "RepositorioPersona.txt";
    public void AltaPersona(Persona persona){
        int id = RepositorioIdPersona.ObtenerId();     //consigue la id en el repo persona
        using StreamWriter sw = new StreamWriter(_nombreArch,true);
        sw.WriteLine(id);
        sw.WriteLine(persona.Dni);
        sw.WriteLine(persona.Nombre);
        sw.WriteLine(persona.Apellido);
        sw.WriteLine(persona.Telefono);
        sw.WriteLine(persona.Email);
        //escribe en el archivo 
    }
    public void BajaPersona(int id){
        using StreamReader st = new StreamReader (_nombreArch,true);

    }
    public void ModificarPersona(Persona persona){

    }
    public Persona? obtenerPersona(int id){         //la persona puede no estar
        List<Persona>lista = ListarPersonas();      //guardo la lista de personas
        Persona? p = lista.Find(Persona => Persona.Id == id);       //busca en la lista la persona comparando por id  (puedo no estar) 
         return p;          //retorna ya sea la persona o null
    }
    public List<Persona> ListarPersonas(){

        List<Persona>resultado = new List<Persona>();  //creo la lista de personas

        using StreamReader sr = new StreamReader (_nombreArch);  
        while (!sr.EndOfStream)  //mientras no termine el archivo
        {
            var Persona = new Persona();
            Persona.Id=int.Parse(sr.ReadLine()?? "");
            Persona.Dni=sr.ReadLine() ?? "";
            Persona.Nombre=sr.ReadLine() ?? "";
            Persona.Apellido=sr.ReadLine() ?? "";
            Persona.Telefono= int.Parse(sr.ReadLine()?? "");
            Persona.Email=sr.ReadLine() ?? "";
            resultado.Add(Persona);

        //leo por linea y lo agrego a la lista.
        }
        
        return resultado;
    }


}

