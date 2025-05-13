namespace CentroEventos.Aplicacion;

public class BajaPersonaUseCase(IRepositorioPersona repo)
{
    public void Ejecutar (int id){
        repo.BajaPersona(id);
    }
}