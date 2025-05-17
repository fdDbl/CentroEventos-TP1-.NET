namespace CentroEventos.Aplicacion;

public class EventoAltaUseCase(IServicioAutorizacion auth,IRepositorioEventoDeportivo repoAct, IRepositorioPersona repoPer, EventoAltaValidadorNombre vNom, EventoAltaValidadorCupoMaximo vCupo)
{
    public void Ejecutar(EventoDeportivo evento, int userId)
    {
        if (!auth.PoseeElPermiso(userId, Permiso.EventoAlta))
        {
            throw new Exception("No posee los permisos para realizar operacion");
        }

        if (!vNom.ValidarEventoAltaNombre(evento, repoPer, out string msg1))
        { // valido
            throw new ValidacionException(msg1);
        }

        if (!vCupo.ValidarEventoAltaCupoMaximo(evento, repoPer, out string msg2))
        { // valido
            throw new ValidacionException(msg2);
        }
 // ... seguir , faltan un par
        repoAct.EventoAlta(evento); // si es valido doy de alta el evento
        
    }
}