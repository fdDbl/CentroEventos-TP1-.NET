using System;

namespace CentroEventos.Aplicacion;

public class EmailValidador
{
    public bool ValidarEmail(string? st, IRepositorioPersona repo, out string msg)
    {
        msg = " ";
        if (st != null)
        {
            if (repo.BuscarPorEmail(st))
            {
                msg += "El Email ya existe";
            }
        }
        return msg == " "; 
    }
}
