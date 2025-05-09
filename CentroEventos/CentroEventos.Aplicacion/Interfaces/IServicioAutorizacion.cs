namespace CentroEventos.Aplicacion;

public interface IServicioAutorizacion
{
    bool PoseeElPermiso(int IdUsuario, TipoPermiso permiso);
}