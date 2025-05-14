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
        persona.Id = id;
        using StreamWriter sw = new StreamWriter(_nombreArch,true);
        sw.WriteLine($"{persona.Id} | {persona.Dni} | {persona.Nombre} | {persona.Apellido} | {persona.Telefono} | {persona.Email}");
    }
    public void BajaPersona(int id)
    {
        List<Persona> personas = ListarPersonas();
        Persona? p = ObtenerPersona (id);
        if (p!=null)
        {
            personas.Remove(p);
            SobreEscribirPersonas(personas);
        }
        else
           throw new RepositorioException("La persona no esta en la lista");
    }

    private void SobreEscribirPersonas(List<Persona>lista)
    {
        using StreamWriter sw = new StreamWriter(_nombreArch,false);  //false para sobreescribir
        foreach (Persona p in lista)
        {
            sw.WriteLine($"{p.Id} | {p.Dni} | {p.Nombre} | {p.Apellido} | {p.Telefono} | {p.Email}");
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
        
        // aprovechá el método obtenerPersona() boludito

    }
    public Persona? ObtenerPersona(int id)
    {         //la persona puede no estar
        var lista = ListarPersonas();      //guardo la lista de personas
        var p = lista.Find(persona => persona.Id == id);       //busca en la lista la persona comparando por id  (puedo no estar) 
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

