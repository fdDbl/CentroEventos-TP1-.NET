using System;
//Villca
using CentroEventos.Aplicacion;
namespace CentroEventos.Repositorios;

public class RepositorioPersona : IRepositorioPersona
{
    private readonly string _nombreArch = @"../../../../CentroEventos.Repositorios/Personas/RepositorioPersona.txt";
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
           throw new EntidadNotFoundException("La persona no esta en la lista");
    }

    private void SobreEscribirPersonas(List<Persona>lista)
    {
        using StreamWriter sw = new StreamWriter(_nombreArch,false);  //false para sobreescribir
        foreach (Persona p in lista)
        {
            sw.WriteLine($"{p.Id} | {p.Dni} | {p.Nombre} | {p.Apellido} | {p.Telefono} | {p.Email}");
        }
    }
    public void ModificarPersona(Persona persona,Persona PersonaModificada){

       List <Persona> listaPersona = ListarPersonas();

        using var sw = new StreamWriter (_nombreArch,false);

        Persona? p= ObtenerPersona (PersonaModificada.Id);    

        if (p!=null)
        {
            p .Id = PersonaModificada.Id;
            p.Dni = PersonaModificada.Dni;
            p.Nombre = PersonaModificada.Nombre;
            p.Apellido = PersonaModificada.Apellido;
            p.Telefono = PersonaModificada.Telefono;
            p.Email = PersonaModificada.Email;
            //HAGO ESTO PORQUE P OBTIENE UNA REFERENCIA AL ELEMENTO DE LA LISTA
            SobreEscribirPersonas(listaPersona);  //escribo en el texto
        }
        else
            {
                throw new EntidadNotFoundException ("La persona no esta en la lista");
                //PREGUNTAR ESTO EL VIERNES 
            }   
    }
    public Persona? ObtenerPersona(int id)
    {         //la persona puede no estar
        var lista = ListarPersonas();      //guardo la lista de personas
        var p = lista.Find(persona => id == persona.Id);       //busca en la lista la persona comparando por id  (puede no estar) 
        //si se pone asi el parametro busca el elemento dentro la lista cuyo id coincide con idNueva
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

