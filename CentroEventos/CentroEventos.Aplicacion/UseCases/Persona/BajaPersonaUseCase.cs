namespace CentroEventos.Aplicacion;

public class BajaPersonaUseCase(IRepositorioPersona repo)
{
    public void Ejecutar (int id){
        // falta chequear que la persona exista. Lo valida un validador, no el repo
        repo.BajaPersona(id);
    }
}