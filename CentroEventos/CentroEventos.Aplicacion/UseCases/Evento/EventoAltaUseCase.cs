namespace CentroEventos.Aplicacion;

public class EventoAltaUseCase(IRepositorioEventoDeportivo repoAct, IRepositorioPersona repoPer, EventoValidador validador)
{
    public void Ejecutar(EventoDeportivo evento)
    {
        if(!validador.ValidarEventoAlta(evento,repoPer,out string msg))
            throw new Exception(msg);
        repoAct.EventoAlta(evento);
    }
}