using ClinicaSalud.models;
using ClinicaSalud.Services;

//Declarar lista
List<Paciente> pacientes = new List<Paciente>();

while (true)
{ 
    Console.WriteLine("Bienvenido a Clinica Salud");
    Console.WriteLine("Por favor selecciona alguna de las siguientes opciones:");
    Console.WriteLine("1. Registrar paciente");
    Console.WriteLine("2. Listar paciente");
    Console.WriteLine("3. Buscar paciente");
    Console.WriteLine("4. Salir");
        
    
    string opcion = Console.ReadLine();
    
    switch (opcion)
    {
        case "1":
            PacienteService.RegistrarPaciente(pacientes);
            break;
        case "2":
            PacienteService.ListarPacientes(pacientes);
            break;
        case "3":
            Console.Write("Por favor ingresa el nombre a buscar: ");
            string name = Console.ReadLine();
            
            PacienteService.BuscarPacientePorNombre(pacientes, name);
            break;
        case "4":
            Console.WriteLine("Hasta la próxima...");
            return;
        default:
            Console.WriteLine("Opción invalida, seleccione una opción correcta");
            break;
    }
}


