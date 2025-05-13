namespace CentroEventos.Aplicacion;

public class EventoAltaUseCase(IRepositorioEventoDeportivo repoAct, IRepositorioPersona repoPer, EventoValidador validador)
{
    public void Ejecutar(EventoDeportivo evento)
    {
        if(!validador.ValidarEvento(evento,repoPer,out string msg))
            throw new Exception(msg);
        repoAct.AltaActividad(evento);
    }
}