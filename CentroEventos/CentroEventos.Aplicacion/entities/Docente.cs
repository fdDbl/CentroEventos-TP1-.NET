namespace CentroEventos.Aplicacion;

public class Docente : Persona
{
    public string? Matricula { get; private set; }
    public DateTime AnioIngreso { get; private set; }

    public Docente(int id, int carnet, string? nombre, string? apellido, int dir, string? facultad, int tel,
        string? email, string? mat, DateTime anioIng) : base(id, carnet, nombre, apellido, dir, facultad, tel, email)
    {
        Matricula = mat;
        AnioIngreso = anioIng;
    }

    public override string ToString()
    {
        return
            $"DOCENTE: {base.ToString()} {Environment.NewLine} Matricula: {Matricula}, Año de ingreso: {AnioIngreso}";
    }
}