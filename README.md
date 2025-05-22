# Seminario .NET - Proyecto Centro de Eventos Deportivos (Primera Entrega)

## Integrantes
* Bie Leandro [cite: 1]
* Castañeda Isabella [cite: 1]
* Dobal Federico [cite: 1]
* Villca Facundo [cite: 1]

## Descripción General del Proyecto
Este proyecto representa un sistema para un Centro de Eventos Deportivos. [cite: 2] Su funcionalidad principal es administrar eventos deportivos y relacionarlos con personas y reservas, utilizando casos de uso habituales. [cite: 3] Toda la información generada se persiste en repositorios de archivos de texto. [cite: 3]

## Objetivos Principales
1.  Proveer un sistema básico para la administración de eventos deportivos, personas y reservas. [cite: 4]
2.  Implementar funcionalidades CRUD (Crear, Leer, Actualizar, Borrar) en los casos de uso del sistema. [cite: 5]
3.  Incorporar validaciones predefinidas al ejecutar los casos de uso. [cite: 6]
4.  Expresar la falla de las validaciones mediante excepciones personalizadas. [cite: 6]
5.  Respetar la inyección de dependencias por constructor. [cite: 7]
6.  Persistir toda la información del CRUD en archivos de texto. [cite: 6]

## Arquitectura del Sistema
El sistema está organizado siguiendo los principios de la Arquitectura Limpia, separando los elementos en "capas" para asegurar que las dependencias fluyan hacia el núcleo del sistema. [cite: 12] Esto permite que el sistema sea sostenible a largo plazo y facilita futuras modificaciones sin necesidad de una reconstrucción completa. [cite: 13]

La estructura se compone de:
* **CentroEventos.Aplicacion**: Es el núcleo de la solución y maneja la lógica del sistema. [cite: 17, 18] No posee referencias a otros módulos. [cite: 16]
* **CentroEventos.Consola**: Es la interfaz de usuario de la solución. [cite: 30] Conoce las referencias de Repositorios y Aplicación. [cite: 14, 16, 30]
* **CentroEventos.Repositorios**: Implementa los métodos para el acceso a datos y controla los archivos de texto. [cite: 40] Conoce las referencias de Aplicación. [cite: 16, 40]

Un diagrama de dependencias de la solución completa se encuentra en el archivo `Diagrama de dependencias - .NET primera entrega.svg`. [cite: 55]

### Componentes de `CentroEventos.Aplicacion`
* **Entities**: `EventoDeportivo`, `Persona`, `Reserva`. [cite: 9, 18]
* **Enums**: `Asistencia` (Pendiente, Presente, Ausente) y `Permiso` (para operaciones de Evento, Reserva y Usuario). [cite: 18, 19]
* **Exceptions**: Excepciones personalizadas como `CupoExcedidoException`, `DuplicadoException`, `EntidadNotFoundException` (lanzada en repositorios), `FalloAutorizacionException`, `OperacionInvalidaException`, y `ValidacionException`. [cite: 19, 20, 21, 22]
* **Interfaces**: `IRepositorioEventoDeportivo`, `IRepositorioPersona`, `IRepositorioReserva`, `IServicioAutorizacion`. [cite: 8, 23]
* **Services**: Implementación de `IServicioAutorizacion`. [cite: 23] En esta entrega, un usuario tiene permiso si su ID es 1. [cite: 24]
* **UseCases**: Implementación de los casos de uso (Alta, Baja, Modificación) con validaciones previas. [cite: 25]
* **Validators**: Clases para asegurar que se cumplen las restricciones necesarias para cada caso de uso, lanzando excepciones si no se cumplen. [cite: 27, 28, 29]

### Componentes de `CentroEventos.Consola`
* **Programa principal**: Crea instancias e inyecta dependencias. [cite: 31] Utiliza un `Selector` para que el usuario controle el flujo del programa. [cite: 32]
* **Selector**: Clase para abstraer la selección en consola, mejorando la legibilidad y seguridad al manejar IDs internamente. [cite: 34, 35, 39] Permite al usuario seleccionar entidades (Personas, Eventos Deportivos, Reservas) de una lista numerada. [cite: 38, 39]

### Componentes de `CentroEventos.Repositorios`
* Implementan las interfaces de repositorio y gestionan los archivos de texto para las entidades. [cite: 10, 40]
* Se encargan de asignar y auto-incrementar los IDs de las entidades, almacenándolos en un archivo de texto separado y gestionándolos internamente. [cite: 41, 42]

## Proceso de Trabajo
El desarrollo fue realizado en equipo. [cite: 43] Inicialmente se intentó usar Live Server para trabajo simultáneo, pero se optó por dividir responsabilidades por entidades y gestionar el proyecto con GitHub, lo cual resultó más efectivo. [cite: 44, 45, 46] Esta división optimizó el ritmo de trabajo, manteniendo una comprensión general del código y facilitando la integración. [cite: 50, 51]

## Conclusión
Esta primera entrega fue una experiencia enriquecedora en el desarrollo de software con .NET y C#. [cite: 52] Se afrontaron desafíos colaborativamente, tanto en dinámicas grupales como en aspectos técnicos (gestión de IDs, arquitectura limpia). [cite: 53] El proyecto respeta el principio de inversión de dependencia y el concepto de arquitectura cebolla. [cite: 54]

## Instrucciones para Correr el Programa

### Prerrequisitos
* Tener instalado el SDK de .NET (la versión utilizada en el proyecto, aunque no especificada, se recomienda usar una versión reciente compatible).

### Pasos para Ejecutar
1.  **Clonar el repositorio**:
    ```bash
    git clone <url-del-repositorio>
    ```
2.  **Navegar al directorio del proyecto**:
    ```bash
    cd <nombre-del-repositorio>
    ```
3.  **Navegar al proyecto de Consola**:
    Se asume que el proyecto ejecutable se encuentra en `CentroEventos.Consola`.
    ```bash
    cd CentroEventos.Consola
    ```
    (Si la estructura del proyecto es diferente, navega al directorio que contiene el archivo `.csproj` del proyecto de consola).

4.  **Ejecutar la aplicación**:
    ```bash
    dotnet run
    ```
    Esto compilará y ejecutará la aplicación de consola. [cite: 30] Siga las instrucciones presentadas en la consola para interactuar con el sistema. [cite: 32, 33]
