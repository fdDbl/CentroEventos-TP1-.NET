namespace CentroEventos.Aplicacion;
// Persona: Id, número de carnet, nombre, apellido, dirección, facultad, teléfono, correo electrónico.
public class Persona {
    static int s_id = 0;
    public static int Id {
        get => s_id;
        
        set => s_id = value +1; // preguntar como debe ser gestionado por el repositorio
        }
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