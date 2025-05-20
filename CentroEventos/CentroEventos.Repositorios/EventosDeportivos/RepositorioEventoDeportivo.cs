using CentroEventos.Aplicacion;
namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivo: IRepositorioEventoDeportivo
{
    readonly string _nomArch= "../../../../CentroEventos.Repositorios/EventosDeportivos/EventosDeportivos.txt";
    public void EventoAlta(EventoDeportivo actividad)
    {
        using StreamWriter sw= new StreamWriter (_nomArch,true);
        actividad.Id = RepositorioEventoDeportivoId.CalcularId();
        sw.WriteLine(actividad.Id);
        sw.WriteLine(actividad.Nombre);
        sw.WriteLine(actividad.Descripcion);
        sw.WriteLine(actividad.FechaHoraInicio);
        sw.WriteLine(actividad.DuracionHoras);
        sw.WriteLine(actividad.CupoMaximo);
        sw.WriteLine(actividad.ResponsableId);
    }

    public void EventoBaja(int id)
    {
        var listaEventos= ListarEventos(); //me guardo la lista de eventos
        var evento = listaEventos.Find(eventoDeportivo=>eventoDeportivo.Id==id); //Busco en la lista el id que recibí como parámetro
        if (evento!=null)
        {
            listaEventos.Remove(evento); //lo saco de la lista
            SobreEscribirEventos(listaEventos); //sobreescribo el archivo
        }
        else
            throw new EntidadNotFoundException("Evento deportivo no existente.");
      
    }

    public int ObtenerIdPorIndice(int index)
    {
        EventoDeportivo e = ListarEventos()[index];
        if (e == null) throw new EntidadNotFoundException("Selección de evento deportivo inválido.");
        return e.Id;
    }

    public EventoDeportivo ObtenerEvento(int id) //Busco el evento por Id
    {
        var listaEventos=ListarEventos(); //me guardo la lista de los eventos
        var evento =listaEventos.Find(eventoDeportivo=>eventoDeportivo.Id==id); //Me guardo en la variable 'evento' null si 
                                                                                //el evento no existe o el mismo evento si existe
        return evento ?? throw new EntidadNotFoundException("Evento deportivo no existente."); //lo devuelvo
    }

    private void SobreEscribirEventos(List<EventoDeportivo> listaEventos)
    {
        using StreamWriter sw= new StreamWriter(_nomArch,false); //false para sobreescribir el archivo
        foreach (EventoDeportivo e in listaEventos)
        {
            sw.WriteLine(e.Id);
            sw.WriteLine(e.Nombre);
            sw.WriteLine(e.Descripcion);
            sw.WriteLine(e.FechaHoraInicio);
            sw.WriteLine(e.DuracionHoras);
            sw.WriteLine(e.CupoMaximo);
            sw.WriteLine(e.ResponsableId);
        }
    }

    public List<EventoDeportivo> ListarEventos()
    {
        using StreamReader sr= new StreamReader(_nomArch);
        List<EventoDeportivo> listaEventos= new List<EventoDeportivo>(); //creo la lista
        while (!sr.EndOfStream) //mientras no sea fin de archivo
        {
            var evento = new EventoDeportivo(); //Asigno cada campo correspondiente
            evento.Id=int.Parse(sr.ReadLine()?? "");
            evento.Nombre=sr.ReadLine()?? "";
            evento.Descripcion=sr.ReadLine() ?? "";
            evento.FechaHoraInicio=DateTime.Parse(sr.ReadLine()?? "");
            evento.DuracionHoras=double.Parse(sr.ReadLine()?? "");
            evento.CupoMaximo=int.Parse(sr.ReadLine()?? "");
            evento.ResponsableId=int.Parse(sr.ReadLine()?? "");
            listaEventos.Add(evento); //Agrego el evento a la lista
        }
        return listaEventos; //Devuelvo la lista
    }

    public void EventoModificacion(EventoDeportivo actMod)
    {
        List <EventoDeportivo> listaAct = ListarEventos(); // creo una lista
        using StreamWriter sw = new StreamWriter(_nomArch,false); // abro el archivo y le paso false para sobreescribir
        foreach (EventoDeportivo act in listaAct)
        { // recorro lista y voy sobreescribiendo
            if (act.Id == actMod.Id)
            { // solo en el caso de que encuentre el q quiero modificar, lo modifico
                act.Nombre = actMod.Nombre;
                act.Descripcion = actMod.Descripcion;
                act.FechaHoraInicio = actMod.FechaHoraInicio;
                act.DuracionHoras = actMod.DuracionHoras;
                act.CupoMaximo = actMod.CupoMaximo;
                act.ResponsableId = actMod.ResponsableId;
                break;
            }
        }
        SobreEscribirEventos(listaAct);
    }


    public List<EventoDeportivo> ListarEventosFuturos()
    {
        List<EventoDeportivo> listaEventos = ListarEventos();
        List<EventoDeportivo> listaEFuturos = new();
        foreach (EventoDeportivo e in listaEventos) {
            if (e.FechaHoraInicio > DateTime.Now) { // si el evento q leo es futuro
                listaEFuturos.Add(e);
            }
        }
        return listaEFuturos;
    }
}



