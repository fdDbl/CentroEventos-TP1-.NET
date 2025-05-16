namespace CentroEventos.Repositorios;
public class RepositorioIdPersona
{
    public static int ObtenerId ()
    {
        string nombreArch = "../../../../CentroEventos.Repositorios/Personas/RepositorioIdPersona.txt";
        using StringReader sr = new StringReader(nombreArch);
        int id = int.Parse(sr.ReadLine() ?? "");            
        id++;
        using StreamWriter st = new StreamWriter (nombreArch);
        st.WriteLine(id);
        return id;
    }
}

