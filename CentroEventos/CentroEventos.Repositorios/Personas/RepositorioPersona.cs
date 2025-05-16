<<<<<<< HEAD
using System;

=======
>>>>>>> 2156dfe85613d3cde0d93cd178677a7109285f84
using CentroEventos.Aplicacion;
namespace CentroEventos.Repositorios;

public class RepositorioPersona : IRepositorioPersona
{
    private readonly string _nombreArch = "../../../../CentroEventos.Repositorios/Personas/RepositorioPersona.txt";
    public void AltaPersona(Persona persona)
    {
        int id = RepositorioIdPersona.ObtenerId();     //consigue la id en el repo persona
        persona.Id = id;
        using StreamWriter sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine($"{persona.Id} | {persona.Dni} | {persona.Nombre} | {persona.Apellido} | {persona.Telefono} | {persona.Email}");
    }
    public void BajaPersona(int id)
    {
        List<Persona> personas = ListarPersonas();
        Persona? p = ObtenerPersona(id);
        if (p != null)
        {
            personas.Remove(p);
            SobreEscribirPersonas(personas);
        }
        else
            throw new EntidadNotFoundException("La persona no esta en la lista");
    }

    private void SobreEscribirPersonas(List<Persona> lista)
    {
        using StreamWriter sw = new StreamWriter(_nombreArch, false);  //false para sobreescribir
        foreach (Persona p in lista)
        {
            sw.WriteLine($"{p.Id} | {p.Dni} | {p.Nombre} | {p.Apellido} | {p.Telefono} | {p.Email}");
        }
    }
<<<<<<< HEAD
    public void ModificarPersona(Persona persona, Persona PersonaModificada)
    {

        List<Persona> listaPersona = ListarPersonas();
=======
    public void ModificarPersona(Persona personaModificada){

        List <Persona> listaPersona = ListarPersonas();
>>>>>>> 2156dfe85613d3cde0d93cd178677a7109285f84

        using var sw = new StreamWriter(_nombreArch, false);

<<<<<<< HEAD
        Persona? personaBuscada = listaPersona.Find(p => p.Id == PersonaModificada.Id);
=======
        Persona? p= ObtenerPersona (personaModificada.Id);    
>>>>>>> 2156dfe85613d3cde0d93cd178677a7109285f84

        if (personaBuscada != null)
        {
<<<<<<< HEAD
            personaBuscada.Id = PersonaModificada.Id;
            personaBuscada.Dni = PersonaModificada.Dni;
            personaBuscada.Nombre = PersonaModificada.Nombre;
            personaBuscada.Apellido = PersonaModificada.Apellido;
            personaBuscada.Telefono = PersonaModificada.Telefono;
            personaBuscada.Email = PersonaModificada.Email;
=======
            p .Id = personaModificada.Id;
            p.Dni = personaModificada.Dni;
            p.Nombre = personaModificada.Nombre;
            p.Apellido = personaModificada.Apellido;
            p.Telefono = personaModificada.Telefono;
            p.Email = personaModificada.Email;
>>>>>>> 2156dfe85613d3cde0d93cd178677a7109285f84
            //HAGO ESTO PORQUE P OBTIENE UNA REFERENCIA AL ELEMENTO DE LA LISTA
            SobreEscribirPersonas(listaPersona);  //escribo en el texto
        }
        else
        {
<<<<<<< HEAD
            throw new EntidadNotFoundException("La persona no esta en la lista");

        }
=======
            throw new EntidadNotFoundException ("La persona no esta en la lista");
            //PREGUNTAR ESTO EL VIERNES 
        }   
>>>>>>> 2156dfe85613d3cde0d93cd178677a7109285f84
    }
    public Persona? ObtenerPersona(int id)
    {         //la persona puede no estar
        var lista = ListarPersonas();      //guardo la lista de personas
        var p = lista.Find(persona => id == persona.Id);       //busca en la lista la persona comparando por id  (puede no estar) 
        //si se pone asi el parametro busca el elemento dentro la lista cuyo id coincide con idNueva
        return p;          //retorna ya sea la persona o null
    }
    public  List<Persona> ListarPersonas()
    {

<<<<<<< HEAD
        List<Persona> resultado = new List<Persona>();  //creo la lista de personas
=======
        List<Persona>resultado = new();  //creo la lista de personas
>>>>>>> 2156dfe85613d3cde0d93cd178677a7109285f84

        using StreamReader sr = new StreamReader(_nombreArch);

        while (!sr.EndOfStream)  //mientras no termine el archivo

        {
<<<<<<< HEAD
            var Persona = new Persona();
            var st = sr.ReadLine() ?? "";
            var split = st.Split();
            Persona.Id = int.Parse(split[0]);
            Persona.Dni = split[1];
            Persona.Nombre = split[2];
            Persona.Apellido = split[3];
            Persona.Telefono = int.Parse(split[4]);
            Persona.Email = split[5];
            resultado.Add(Persona);
=======
            var persona = new Persona();
            persona.Id=int.Parse(sr.ReadLine()?? "");
            persona.Dni=sr.ReadLine() ?? "";
            persona.Nombre=sr.ReadLine() ?? "";
            persona.Apellido=sr.ReadLine() ?? "";
            persona.Telefono= int.Parse(sr.ReadLine()?? "");
            persona.Email=sr.ReadLine() ?? "";
            resultado.Add(persona);
        //leo por linea y lo agrego a la lista.
        }
        
        return resultado;
>>>>>>> 2156dfe85613d3cde0d93cd178677a7109285f84

        }
        return resultado;
    }
    public  bool BuscarPorDni(string? dni)
    {
        List<Persona> l = ListarPersonas();

        Persona? p = l.Find(persona => persona.Dni == dni);

        if (p != null)
        {
            if (p.Dni == dni) return true;
        }
        return true;
    }

    public  bool BuscarPorEmail(string? email)
    {
        List<Persona> l = ListarPersonas();

        Persona? p = l.Find(persona => persona.Email == email);

        if (p != null)
        {
            if (p.Email == email) return true;
        }
        return true;
    }
}


