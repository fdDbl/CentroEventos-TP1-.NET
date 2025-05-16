namespace CentroEventos.Aplicacion;
// Persona: Id, dni, nombre, apellido, teléfono, correo electrónico.
public class Persona {
    public int Id { get; set; }
    public string? Dni {get;set;}
    public string? Nombre {get;set;}
    public string? Apellido {get;set;}
    public int Telefono {get;set;}
    public string? Email {get;set;}

    public Persona (){}
    
    public Persona ( String unNro, string? unNom, string? unAp,int unTel, string? unEm) 
    {
        Dni = unNro;
        Nombre = unNom;
        Apellido = unAp;
        Telefono = unTel;
        Email = unEm;
    }

    public override string ToString()
    {
        return $"ID: {Id},dni: {Dni}, nombre: {Nombre}, apellido: {Apellido}, {Environment.NewLine} telefono: {Telefono}, correo electronico: {Email} ";
    }
}