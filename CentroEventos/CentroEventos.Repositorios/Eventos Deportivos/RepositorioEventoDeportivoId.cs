using CentroEventos.Aplicacion;
namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivoId {
    public static int CalcularId () {
        string nomArch = "RepositorioEventoDeportivoId.txt";
        int id = 1;
        if (File.Exists(nomArch)) {
            using var sr = new StreamReader(nomArch);
            id = int.Parse(sr.ReadLine()?? "");
            id++;
            using var sw = new StreamWriter(nomArch);
            sw.WriteLine(id);
        }
        else {
            using var sw = new StreamWriter(nomArch,false);
            sw.WriteLine(id);
        }
        return id;
    } 
}