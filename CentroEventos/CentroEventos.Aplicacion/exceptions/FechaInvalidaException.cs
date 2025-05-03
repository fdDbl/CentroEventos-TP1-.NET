namespace CentroEventos.Aplicacion;
public class FechaInvalidaException : Exception
{
    public FechaInvalidaException() {}
    public FechaInvalidaException(string message): base(message){}
    public FechaInvalidaException (string message, Exception inner) : base(message, inner) {}
}