namespace CentroEventos.Aplicacion;

public class ModificarPersonaUseCase(IRepositorioPersona repo)
{
    public void Ejecutar (Persona persona ){
        repo.ModificarPersona(persona); // falta parámetro (no hace falta que se devuelva la persona modificada por parámetro)
    }
}