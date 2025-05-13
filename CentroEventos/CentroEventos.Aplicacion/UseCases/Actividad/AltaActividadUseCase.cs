namespace CentroEventos.Aplicacion;

public class AltaActividadUseCase(IRepositorioEventoDeportivo repoAct, IRepositorioPersona repoPer, ActividadValidador validador)
{
    public void Ejecutar(EventoDeportivo actividad)
    {
        if(!validador.ValidarActividad(actividad,repoPer,out string msg))
            throw new Exception(msg);
        repoAct.AltaActividad(actividad);
    }
}