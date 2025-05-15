namespace CentroEventos.Repositorios;
public class RepositorioIdPersona
{
    public static int ObtenerId ()
    {
        string _nombreArch = @"../../../../CentroEventos.Repositorios/Personas/RepositorioIdPersona.txt";
        using StringReader sr = new StringReader(_nombreArch);
        int id = int.Parse(sr.ReadLine() ?? "");            
        id++;
        using StreamWriter st = new StreamWriter (_nombreArch);
        st.WriteLine(id);
        return id;
    }
}

