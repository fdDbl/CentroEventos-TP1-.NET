namespace CentroEventos.Aplicacion;
// Persona: Id, número de carnet, nombre, apellido, dirección, facultad, teléfono, correo electrónico.
public class Persona {
    public int Id { get; set; }
    public string? Nombre {get;set;}
    public string? Apellido {get;set;}
    public int Telefono {get;set;}
    public string? Email {get;set;}

    public Persona (/*int unId,*/ int unNro, string? unNom, string? unAp, int unaDire, string? unaF, int unTel, string? unEm) {
        //Id = unId;
        Nombre = unNom;
        Apellido = unAp;
        Telefono = unTel;
        Email = unEm;
    }

    public override string ToString() {
        return $"ID: {Id}, nombre: {Nombre}, apellido: {Apellido}, {Environment.NewLine} telefono: {Telefono}, correo electronico: {Email} ";
    }
}