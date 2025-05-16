using System.Reflection.Metadata;

namespace CentroEventos.Aplicacion;

public interface IRepositorioPersona
{
    void AltaPersona(Persona persona);
    void BajaPersona(int id);
    void ModificarPersona(Persona personaModificada);
    Persona? ObtenerPersona(int id);
    List<Persona> ListarPersonas();

    bool BuscarPorDni(string? dni);

    bool BuscarPorEmail(string? Email);
    
}