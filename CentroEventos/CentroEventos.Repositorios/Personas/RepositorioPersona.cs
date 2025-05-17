
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
    }

    private void SobreEscribirPersonas(List<Persona> lista)
    {
        using StreamWriter sw = new StreamWriter(_nombreArch, false);  //false para sobreescribir
        foreach (Persona p in lista)
        {
            sw.WriteLine($"{p.Id} | {p.Dni} | {p.Nombre} | {p.Apellido} | {p.Telefono} | {p.Email}");
        }
    }
    public void ModificarPersona(Persona persona, Persona PersonaModificada)
    {

        List<Persona> listaPersona = ListarPersonas();

        using var sw = new StreamWriter(_nombreArch, false);

        Persona? personaBuscada = listaPersona.Find(p => p.Id == PersonaModificada.Id);

        if (personaBuscada != null)
        {
            personaBuscada.Id = PersonaModificada.Id;
            personaBuscada.Dni = PersonaModificada.Dni;
            personaBuscada.Nombre = PersonaModificada.Nombre;
            personaBuscada.Apellido = PersonaModificada.Apellido;
            personaBuscada.Telefono = PersonaModificada.Telefono;
            personaBuscada.Email = PersonaModificada.Email;
            //HAGO ESTO PORQUE P OBTIENE UNA REFERENCIA AL ELEMENTO DE LA LISTA
            SobreEscribirPersonas(listaPersona);  //escribo en el texto
        }
        else
        {
            throw new EntidadNotFoundException("La persona no esta en la lista");

        }
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

        List<Persona> resultado = new List<Persona>();  //creo la lista de personas

        using StreamReader sr = new StreamReader(_nombreArch);

        while (!sr.EndOfStream)  //mientras no termine el archivo

        {
            var Persona = new Persona();
            var st = sr.ReadLine() ?? "";
            var split = st.Split(" | ");
            Persona.Id = int.Parse(split[0]);
            Persona.Dni = split[1];
            Persona.Nombre = split[2];
            Persona.Apellido = split[3];
            Persona.Telefono = int.Parse(split[4]);
            Persona.Email = split[5];
            resultado.Add(Persona);

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
        return false;
    }

    public  bool BuscarPorEmail(string? email)
    {
        List<Persona> l = ListarPersonas();

        Persona? p = l.Find(persona => persona.Email == email);

        if (p != null)
        {
            if (p.Email == email) return true;
        }
        return false;
    }
}














