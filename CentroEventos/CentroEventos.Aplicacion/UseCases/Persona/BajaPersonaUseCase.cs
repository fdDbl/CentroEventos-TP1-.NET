using CentroEventos.Aplicacion.Validators.Persona;

namespace CentroEventos.Aplicacion;

public class BajaPersonaUseCase(IRepositorioPersona repo,IRepositorioEventoDeportivo repoEventoDeportivo,PersonaBajaValidador validador)
{
    public void Ejecutar(int id)
    {
        // falta chequear que la persona exista. Lo valida un validador, no el repo
        if (!validador.validar(id,repoEventoDeportivo,out string msg))
            throw new ValidacionException(msg);
         repo.BajaPersona(id);
    }
}   