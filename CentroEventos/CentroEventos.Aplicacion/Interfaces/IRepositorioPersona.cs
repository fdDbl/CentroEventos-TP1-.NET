namespace CentroEventos.Aplicacion;

public interface IRepositorioPersona
{
    void AltaPersona(Persona persona);
    void BajaPersona(int id);
    void ModificarPersona(Persona persona, Persona PersonaModificada);
    Persona? ObtenerPersona(int id);
    List<Persona> ListarPersonas();
}