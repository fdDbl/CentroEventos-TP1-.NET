using CentroEventos.Aplicacion;

namespace CentroEventos.Consola;
public class Selector
{
    public void Personas(ListarPersonasUseCase listarPersonas, out int index)
    {
        var lista = listarPersonas.Ejecutar();
        for(int i = 1; i <= lista.Count; i++) {
            Console.WriteLine($"{i}) {lista[i-1]}");
        }
        index = int.Parse(Console.ReadLine() ?? "-1") - 1;
    }
    public void Reservas(ReservaListarUseCase listarReservas, out int index)
    {
        var lista = listarReservas.Ejecutar();
        for(int i = 1; i <= lista.Count; i++) {
            Console.WriteLine($"{i}) {lista[i-1]}");
        }
        index = int.Parse(Console.ReadLine() ?? "-1") - 1;
    }
    public void EventosDeportivos(EventoListarUseCase listarEventos, out int index)
    {
        var lista = listarEventos.Ejecutar();
        for(int i = 1; i <= lista.Count; i++) {
            Console.WriteLine($"{i}) {lista[i-1]}");
        }
        index = int.Parse(Console.ReadLine() ?? "-1") - 1;
    }
}