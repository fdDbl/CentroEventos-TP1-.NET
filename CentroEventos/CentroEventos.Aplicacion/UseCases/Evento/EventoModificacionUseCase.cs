namespace CentroEventos.Aplicacion;

public class EventoModificacionUseCase(IServicioAutorizacion auth,
IRepositorioEventoDeportivo repoEven, IRepositorioReserva repoR, IRepositorioPersona repoPer,
 EventoModificadorValidadorFecha vFec, EventoModificadorValidadorCupo vCupo,
 EventoModificadorValidadorIdResponsable vId) {

    public void Ejecutar(EventoDeportivo unEvento, int userId) //
    {
        if (auth.PoseeElPermiso(userId, Permiso.EventoModificacion))
        {
            if (!vFec.ValidarEventoModificacionFecha(unEvento, repoEven, out string msg))
            {
                throw new ValidacionException(msg);
            }
            if (!vCupo.ValidarEventoModificacionCupoMax(unEvento, repoR, out string msg1))
            {
                throw new CupoExcedidoException(msg1);
            }
            if (!vId.ValidarEventoModificacionIdResponsable(unEvento, repoPer, out string msg2))
            {
                throw new EntidadNotFoundException(msg2);
            }
            repoEven.EventoModificacion(unEvento);
        }
        else throw new FalloAutorizacionException("No se poseen permisos para realizar esta accion");
    }
}