using CentroEventos.Aplicacion.Validators.Persona;

namespace CentroEventos.Aplicacion;

public class BajaPersonaUseCase(IServicioAutorizacion auth, IRepositorioPersona repo,IRepositorioEventoDeportivo repoEventoDeportivo,PersonaBajaValidador validador)
{
    public void Ejecutar(int id, int unId)
    {
        if (!auth.PoseeElPermiso(unId, Permiso.UsuarioBaja))
            throw new FalloAutorizacionException("No posee el permiso para dar de baja una Persona");
        // falta chequear que la persona exista. Lo valida un validador, no el repo
        if (!validador.Validar(id,repoEventoDeportivo,out string msg))
            throw new ValidacionException(msg);
        repo.BajaPersona(id);
    }
}   