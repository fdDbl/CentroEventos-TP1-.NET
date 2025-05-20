using CentroEventos.Aplicacion;

namespace CentroEventos.Consola;
public class Selector
{
    public static void OpcionesMain(out int op)
    {
        Console.WriteLine("----- MENÚ PRINCIPAL -----");
        Console.WriteLine("Seleccione con cuál entidad trabajar (1-3):");
        Console.WriteLine("1) Personas\n2) Eventos deportivos\n3)Reservas");
        op = int.Parse(Console.ReadLine() ?? "-1");
        do {
            switch (op)
            {
                case 1: 
                    Console.WriteLine("- GESTIÓN DE PERSONAS -");
                    break;
                case 2:
                    Console.WriteLine("- GESTIÓN DE EVENTOS DEPORTIVOS -");
                    break; 
                case 3:
                    Console.WriteLine("- GESTIÓN DE RESERVAS -");
                    break;
                default: 
                    Console.WriteLine("Opción incorrecta.");
                    break;
            }
        } while (op < 1 && op > 4);
    }

    public static void OpcionesEntidad(string entidad, out int op)
    {
        Console.WriteLine($"----- MENÚ DE {entidad} -----");
        Console.WriteLine("Seleccione qué hacer:");
        Console.WriteLine("1) Alta\n2) Baja\n3) Modificar\n4) Listar");
        op = int.Parse(Console.ReadLine() ?? "-1");
        do
        {
            switch (op)
            {
                case 1:
                    Console.WriteLine($"- ALTA DE {entidad} -");
                    break;
                case 2:
                    Console.WriteLine($"- BAJA DE {entidad} -");
                    break;
                case 3:
                    Console.WriteLine($"- MODIFICACIÓN DE {entidad} -");
                    break;
                case 4:
                    Console.WriteLine($"- LISTADO DE {entidad} -");
                    break;
                default:
                    Console.WriteLine("Opción incorrecta.");
                    break;
            }
        } while (op < 1 && op > 4);
    }
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