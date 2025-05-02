namespace CentroEventos.Aplicacion;
// Persona: Id, número de carnet, nombre, apellido, dirección, facultad, teléfono, correo electrónico.
public abstract class Persona {
    public int Id {get;set;}
    public int Carnet {get;set;}
    public string? Nombre {get;set;}
    public string? Apellido {get;set;}
    public int Direccion {get;set;}
    public string? Facultad {get;set;}
    public int Telefono {get;set;}
    public string? Email {get;set;}

    public Persona (int unId, int unNro, string? unNom, string? unAp, int unaDire, string? unaF, int unTel, string? unEm) {
        Id = unId;
        Carnet = unNro;
        Nombre = unNom;
        Apellido = unAp;
        Direccion = unaDire;
        Facultad = unaF;
        Telefono = unTel;
        Email = unEm;
    }

    public override string ToString() {
        return $"ID: {Id}, numero de carnet: {Carnet}, nombre: {Nombre}, apellido: {Apellido}, {Environment.NewLine} direccion: {Direccion}, facultad: {Facultad}, {Environment.NewLine} telefono: {Telefono}, correo electronico: {Email} ";
    }
}