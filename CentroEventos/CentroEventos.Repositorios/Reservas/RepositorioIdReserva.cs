namespace CentroEventos.Repositorios;

public class RepositorioIdReserva
{
    public static int NextIdActual()
    {
        string nombreArch = "../../../../CentroEventos.Repositorios/Reservas/RepositorioIdReserva.txt";
        if (!File.Exists(nombreArch))
        {
            using var swId = new StreamWriter(nombreArch);
            swId.WriteLine("1");
        }
        using StringReader sr = new StringReader(nombreArch);
        int id = int.Parse(sr.ReadLine() ?? "1");
        id++;
        using StreamWriter st = new StreamWriter(nombreArch,false);
        st.WriteLine(id);
        return id;
    }
}