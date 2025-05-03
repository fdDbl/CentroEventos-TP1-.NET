namespace CentroEventos.Aplicacion;
public class Usuario
{
    public string? Email {get;set;}
    public string? Contrasenia {get;set;}
    public string? Nombre {get;set;}
    public Permiso Permiso {get;set;}

    public Usuario(string? email,string? contrasenia,string? nombre, Permiso permiso)
    {
        Email=email;
        Contrasenia=contrasenia;
        Nombre=nombre;
        Permiso=permiso;
    }

    
}