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
        throw new NotImplementedException();
    }

    public List<EventoDeportivo> ListarActividades()
    {
        throw new NotImplementedException();
    }

    public void ModificarActividad(EventoDeportivo actividad)
    {
        Console.WriteLine("Ingrese hora de inicio para modificarla:");
        actividad.FechaHoraInicio = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese cupo maximo para modificarlo:");
        actividad.CupoMaximo = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese duracion para modificarla:");
        actividad.DuracionHoras = int.Parse(Console.ReadLine());
        using StreamReader sr = new StreamReader (nomArch) 
        while (!sr.EndOfStream) {
            if (actividad.Nombre == sr.ReadLine()) {
                sr.Read();
                //sr.WriteLine(actividad.FechaHoraInicio); // <-- xq no me lo toma ? tengo q sobre escribir (actualizar archivo con modificaciones)
            }     
                sr.Read();
                }
        }
    }


