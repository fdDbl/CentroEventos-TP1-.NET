namespace CentroEventos.Aplicacion;

public class Estudiante : Persona {
    public int NroAlumno { get; private set; }
    public string? Carrera { get; private set; }
    public Estudiante(int id, int carnet, string? nombre, string? apellido, int dir, string? facultad, int tel, string? email, int nroA, string? car) : base(id, carnet, nombre, apellido, dir, facultad, tel, email) {
        NroAlumno = nroA;
        Carrera = car;
    }
    public override string ToString() {
        return $"ESTUDIANTE: {base.ToString()} {Environment.NewLine} Nro. de alumno: {NroAlumno}, Carrera: {Carrera}";
    }
}