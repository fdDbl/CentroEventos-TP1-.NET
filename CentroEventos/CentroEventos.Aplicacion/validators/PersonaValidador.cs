using System.Net.Cache;
using System.Numerics;

namespace CentroEventos.Aplicacion;

public class PersonaValidador
{
    public bool ValidarPersona(Persona persona,IRepositorioPersona repo, out string msg)
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

        //falta DNI NO PUEDE REPETIRSE ENTRE PERSONAS
        //FALTA EMAIL NO PUEDE REPETIRSE ENTRE PERSONAS
        return msg == "";
    }
}   