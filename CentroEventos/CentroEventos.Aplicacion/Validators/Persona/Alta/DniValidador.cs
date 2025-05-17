using System;

namespace CentroEventos.Aplicacion;

public class DniValidador
{
    public bool Validar(string? st, IRepositorioPersona repo, out string msg)
    {
        msg = " ";
        if (st != null)
        {
            if (repo.BuscarPorDni(st))
                msg += "El dni ya existe";
        }
        return msg == " ";
    }
}
