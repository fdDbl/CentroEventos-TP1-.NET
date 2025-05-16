namespace CentroEventos.Aplicacion;
public class ReservaAltaUseCase(IServicioAutorizacion auth, 
    IRepositorioReserva repoR, IRepositorioEventoDeportivo repoE, 
    IRepositorioPersona repoP, ReservaValidador_AltaExistencias vExistencias, 
    ReservaValidador_AltaDuplicado vDuplicados, ReservaAlta_CupoDisponible vCupo)
{
    public void Ejecutar(Reserva reserva, int idUser)
    {
        string msg;
        
        if (!auth.PoseeElPermiso(idUser, Permiso.ReservaAlta)) 
            throw new FalloAutorizacionException("No posee los permisos para hacer alta de una reserva.");
        if (!vExistencias.Validar(reserva, repoP, repoE, out msg)) throw new EntidadNotFoundException(msg);
        if(!vDuplicados.Validar(reserva, repoR, out msg)) throw new DuplicadoException(msg);
        if (!vCupo.Validar(reserva, repoR, repoE, out msg)) throw new CupoExcedidoException(msg);
        
        repoR.AltaReserva(reserva);
    }
}