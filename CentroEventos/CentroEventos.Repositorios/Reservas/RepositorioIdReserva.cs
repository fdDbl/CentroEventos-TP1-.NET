namespace CentroEventos.Repositorios;

public class RepositorioIdReserva
{
    public static int NextIdActual()
    {
        string _nombreArch = @"../../../../CentroEventos.Repositorios/Reservas/RepositorioIdReserva.txt";
        if (!File.Exists(_nombreArch))
        {
            using var swId = new StreamWriter(_nombreArch);
            swId.WriteLine("1");
        }
        using StringReader sr = new StringReader(_nombreArch);
        int id = int.Parse(sr.ReadLine() ?? "1");
        id++;
        using StreamWriter st = new StreamWriter(_nombreArch,false);
        st.WriteLine(id);
        return id;
    }
}