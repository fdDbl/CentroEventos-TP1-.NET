namespace CentroEventos.Aplicacion.UseCases.Actividad;

public class EventoModificacionUseCase(EventoDeportivo unEvento,IRepositorioEventoDeportivo repoEven, EventoModificadorValidador validador) {

    public void Ejecutar () {
        if (!validador.ValidarEvento(unEvento,repoEven,out string msg)) {
            throw new Exception(msg);
    }
    repoEven.ModificarActividad(unEvento);
}
}