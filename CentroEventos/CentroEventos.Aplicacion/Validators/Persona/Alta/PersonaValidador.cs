namespace CentroEventos.Aplicacion;

public class PersonaValidador
{
    public bool ValidarPersona(Persona persona, IRepositorioPersona repo, out string msg)
    {
        msg = "";
        if (string.IsNullOrWhiteSpace(persona.Nombre))
            msg += "El nombre no debe estar vacio\n";
        if (string.IsNullOrWhiteSpace(persona.Apellido))
            msg += "El apellido no debe estar vacio\n";
        if (string.IsNullOrWhiteSpace(persona.Email))
            msg += "El email no debe estar vacio\n";
        if (string.IsNullOrWhiteSpace(persona.Dni))
            msg += "El dni no debe estar vacio";
        if (repo.BuscarPorEmail(persona.Email))
            msg += "El email  no debe repetirse";
        if (repo.BuscarPorDni(persona.Dni))
            msg += "El dni no debe repetirse";
        return msg == "";

    }



}   
