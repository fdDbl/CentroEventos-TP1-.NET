namespace CentroEventos.Aplicacion;

public class EventoAltaUseCase(IRepositorioEventoDeportivo repoAct, IRepositorioPersona repoPer, EventoAltaValidador validador)
{
    public void Ejecutar(EventoDeportivo evento)
    {
        if(!validador.ValidarEventoAlta(evento,repoPer,out string msg)) // valido
            throw new Exception(msg);
        repoAct.EventoAlta(evento); // si es valido doy de alta el evento
    }
}