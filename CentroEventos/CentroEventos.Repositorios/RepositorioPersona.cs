using System;
//Villca
using CentroEventos.Aplicacion;
namespace CentroEventos.Repositorios;

public class RepositorioPersona : IRepositorioPersona
{
    private readonly string _nombreArch = "RepositorioPersona.txt";
    public void AltaPersona(Persona persona)
    {
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
    public void BajaPersona(int id)
    {
        List<Persona> personas = ListarPersonas();
        Persona? p = obtenerPersona (id);
        if (p!=null)
        {
            personas.Remove(p);
            SobreEscribirPersonas(personas);
        }
        else
           throw new ArgumentException("La persona no esta en la lista");
    }

    private void SobreEscribirPersonas(List<Persona>lista)
    {
        using StreamWriter sw = new StreamWriter(_nombreArch,false);  //false para sobreescribir
        foreach (Persona p in lista)
        {
            sw.WriteLine(p.Id);
            sw.WriteLine(p.Dni);
            sw.WriteLine(p.Nombre);
            sw.WriteLine(p.Apellido);
            sw.WriteLine(p.Telefono);
            sw.WriteLine(p.Email);  
            //sobreescribo el archivo
        }
    }
    public void ModificarPersona(Persona persona){
       List <Persona> listaPersona = ListarPersonas();
        using var sw = new StreamWriter (_nombreArch,false);
        foreach (Persona lista in listaPersona){
            if (lista.Id == persona.Id)
            {
                lista.Dni = persona.Dni;
                lista.Nombre=persona.Nombre;
                lista.Apellido=persona.Apellido;
                lista.Email=persona.Email;
                lista.Telefono=persona.Telefono;
            }
        sw.WriteLine(lista.Id);
        sw.WriteLine(lista.Dni);
        sw.WriteLine(lista.Nombre);
        sw.WriteLine(lista.Apellido);
        sw.WriteLine(lista.Telefono);
        sw.WriteLine(lista.Email);  
        }


    }
    public Persona? obtenerPersona(int id)
    {         //la persona puede no estar
        List<Persona>lista = ListarPersonas();      //guardo la lista de personas
        Persona? p = lista.Find(Persona => Persona.Id == id);       //busca en la lista la persona comparando por id  (puedo no estar) 
        return p;          //retorna ya sea la persona o null
    }
    public List<Persona> ListarPersonas()
    {

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

