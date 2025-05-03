namespace CentroEventos.Aplicacion;
public class Usuario
{
    public string? Email {get;set;}
    public string? Contrasenia {get;set;}
    public string? Nombre {get;set;}
    public TipoPermiso TipoPermiso {get;set;}

    public Usuario(string? email,string? contrasenia,string? nombre, TipoPermiso tipoPermiso)
    {
        Email=email;
        Contrasenia=contrasenia;
        Nombre=nombre;
        TipoPermiso=tipoPermiso;
    }

    
}