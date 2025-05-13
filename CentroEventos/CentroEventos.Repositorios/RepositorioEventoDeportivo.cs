using System;
using CentroEventos.Aplicacion;
namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivo: IRepositorioEventoDeportivo
{
    readonly string nomArch="EventosDeportivos.txt";
    public void AltaActividad(EventoDeportivo actividad)
    {
        using StreamWriter sr= new StreamWriter (nomArch);
        sr.WriteLine(actividad.Id);
        sr.WriteLine(actividad.Nombre);
        sr.WriteLine(actividad.Descripcion);
        sr.WriteLine(actividad.FechaHoraInicio);
        sr.WriteLine(actividad.DuracionHoras);
        sr.WriteLine(actividad.CupoMaximo);
        sr.WriteLine(actividad.ResponsableId);
    }

    public void BajaActividad(int id)
    {
        List<EventoDeportivo> listaEventos= ListarEventos();
        EventoDeportivo? evento=new EventoDeportivo();
        evento=listaEventos.Find(EventoDeportivo=> EventoDeportivo.Id==id);
        if (evento!=null)
        {
            listaEventos.Remove(evento);
            SobreEscribirArchivo(listaEventos);
        }
        else
            throw new EntidadNotFoundException("No existe un evento con ese id.\n"); //Falta crear la clase EntidadNotFoundException
                                                                                    //Esto iría en el useCase?
    }

    private void SobreEscribirArchivo(List<EventoDeportivo> listaEventos)
    {
        using StreamWriter sw= new StreamWriter(nomArch,false); //false para sobreescribir el archivo
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

    public List<EventoDeportivo> ListarActividades()
    {
        using StreamReader sr= new StreamReader(nomArch);
        List<EventoDeportivo> listaEventos= new List<EventoDeportivo>(); //creo la lista
        while (!sr.EndOfStream) //mientras no sea fin de archivo
        {
            var Evento=new EventoDeportivo(); //Asigno cada campo correspondiente
            Evento.Id=int.Parse(sr.ReadLine()?? "");
            Evento.Nombre=sr.ReadLine()?? "";
            Evento.Descripcion=sr.ReadLine() ?? "";
            Evento.FechaHoraInicio=DateTime.Parse(sr.ReadLine()?? "");
            Evento.DuracionHoras=double.Parse(sr.ReadLine()?? "");
            Evento.CupoMaximo=int.Parse(sr.ReadLine()?? "");
            Evento.ResponsableId=int.Parse(sr.ReadLine()?? "");
            listaEventos.Add(Evento); //Agrego el evento a la lista
        }
        return listaEventos; //Devuelvo la lista
    }

    public void ModificarActividad(EventoDeportivo actividad)
    {
        Console.WriteLine("Ingrese hora de inicio para modificarla:");
        actividad.FechaHoraInicio = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese cupo maximo para modificarlo:");
        actividad.CupoMaximo = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese duracion para modificarla:");
        actividad.DuracionHoras = int.Parse(Console.ReadLine());
        using StreamReader sr = new StreamReader (nomArch) ;
        while (!sr.EndOfStream) {
            if (actividad.Nombre == sr.ReadLine()) {
                sr.Read();
                //sr.WriteLine(actividad.FechaHoraInicio); // <-- xq no me lo toma ? tengo q sobre escribir (actualizar archivo con modificaciones)
            }     
                sr.Read();
                }
        }
    }


