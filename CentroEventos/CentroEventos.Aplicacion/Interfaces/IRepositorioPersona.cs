namespace CentroEventos.Aplicacion;

public interface IRepositorioPersona
{
    void AltaPersona(Persona persona);
    void BajaPersona(int id);
    void ModificarPersona(Persona p,Persona personaModificada);
    int ObtenerIdPorIndice(int index);
    Persona? ObtenerPersona(int id);
    List<Persona> ListarPersonas();
    bool BuscarPorDni(string? dni);
    bool BuscarPorEmail(string? email);
}