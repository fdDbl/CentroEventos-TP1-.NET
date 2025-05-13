namespace CentroEventos.Aplicacion;

public class EventoAltaUseCase(IRepositorioEventoDeportivo repoAct, IRepositorioPersona repoPer, EventoAltaValidador validador)
{
    public void Ejecutar(EventoDeportivo evento)
    {
        if(!validador.ValidarEvento(evento,repoPer,out string msg)) // valido
            throw new Exception(msg);
        repoAct.AltaActividad(evento); // si es valido doy de alta el evento
    }
}