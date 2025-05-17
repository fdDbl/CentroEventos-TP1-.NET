using CentroEventos.Aplicacion;
namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivo: IRepositorioEventoDeportivo
{
    readonly string _nomArch= "../../../../CentroEventos.Repositorios/EventosDeportivos/EventosDeportivos.txt";
    public void EventoAlta(EventoDeportivo actividad)
    {
        using StreamWriter sr= new StreamWriter (_nomArch,true);
        actividad.Id = RepositorioEventoDeportivoId.CalcularId();
        sr.WriteLine(actividad.Id);
        sr.WriteLine(actividad.Nombre);
        sr.WriteLine(actividad.Descripcion);
        sr.WriteLine(actividad.FechaHoraInicio);
        sr.WriteLine(actividad.DuracionHoras);
        sr.WriteLine(actividad.CupoMaximo);
        sr.WriteLine(actividad.ResponsableId);
    }

    public void EventoBaja(int id)
    {
        List<EventoDeportivo> listaEventos= ListarEventos(); //me guardo la lista de eventos
        EventoDeportivo evento = ObtenerEvento(id); //llamo al método que busca el evento por id
        listaEventos.Remove(evento); //lo saco de la lista (en el validador me aseguro que no sea null)
        SobreEscribirEventos(listaEventos); //sobreescribo el archivo
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
            sw.WriteLine(); // salto de linea
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

    public void EventoModificacion(EventoDeportivo ActMod)
    {
        using StreamWriter sw = new StreamWriter(_nomArch,false); // abro el archivo y le paso false para sobreescribir
        List <EventoDeportivo> listaAct = ListarEventos(); // creo una lista
        foreach (EventoDeportivo act in listaAct) { // recorro lista y voy sobreescribiendo
            if (act.Id == ActMod.Id) { // solo en el caso de que encuentre el q quiero modificar, lo modifico
                sw.WriteLine(ActMod.Nombre);
                sw.WriteLine(ActMod.Descripcion);
                sw.WriteLine(ActMod.FechaHoraInicio);
                sw.WriteLine(ActMod.DuracionHoras);
                sw.WriteLine(ActMod.CupoMaximo);
                sw.WriteLine(ActMod.ResponsableId);
            }
        sw.WriteLine(act.Id);
        sw.WriteLine(act.Nombre);
        sw.WriteLine(act.Descripcion);
        sw.WriteLine(act.FechaHoraInicio);
        sw.WriteLine(act.DuracionHoras);
        sw.WriteLine(act.CupoMaximo);
        sw.WriteLine(act.ResponsableId);
        }
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



