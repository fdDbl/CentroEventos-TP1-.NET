namespace CentroEventos.Aplicacion.UseCases.Actividad;

public class EventoModificacionUseCase(IServicioAutorizacion auth,IRepositorioEventoDeportivo repoEven, EventoModificadorValidador validador) {

    public void Ejecutar(EventoDeportivo unEvento,int userId)
    {
        if (auth.PoseeElPermiso(userId, Permiso.EventoModificacion))
        {
            if (!validador.ValidarEvento(unEvento, repoEven, out string msg))
            {
                throw new Exception(msg);
            }
            repoEven.EventoModificacion(unEvento);
        }
    }
}