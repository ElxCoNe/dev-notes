using ClinicaSalud.models;

namespace ClinicaSalud.Services
{
    class PacienteService
    {
        
        public static void RegistrarPaciente(List<Paciente> pacientes)
        {
            Paciente paciente = new Paciente();
            
            Console.WriteLine("Registrando paciente...");
            Console.WriteLine("Por favor ingresa la siguiente información->");
    
            //Id paciente
            paciente.Id = pacientes.Count + 1;
    
            //Ingresar el nombre del paciente
            Console.Write("Ingresa el nombre del paciente: ");
            paciente.Nombre = Console.ReadLine();
    
            //Ingresar edad del paciente
            Console.Write("Por favor ingresa la edad del paciente: ");
            try
            {
                paciente.Edad = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine();
                throw;
            }
    
            //Ingresar lel sintoma del paciente
            Console.Write("Por favor ingrese el sintoma del paciente: ");
            paciente.Sintomas = Console.ReadLine();
    
            pacientes.Add(paciente);
    
            Console.WriteLine($"El paciente {paciente.Nombre} fue registrado con exito");

            
        }


        public static void ListarPacientes(List<Paciente> pacientes)
        {
            if (pacientes.Count == 0)
            {
                Console.WriteLine("No hay pacientes registrados");
                return;
            }
            foreach (var paciente in pacientes)
            {
                Console.WriteLine($"Id: {paciente.Id}");
                Console.WriteLine($"Nombre: {paciente.Nombre}");
                Console.WriteLine($"Edad: {paciente.Edad}");
                Console.WriteLine($"Sintoma: {paciente.Sintomas}");
                
            }
        }


        public static void BuscarPacientePorNombre(List<Paciente> pacientes, string name)
        {
            foreach (var paciente in pacientes)
            {
                if (paciente.Nombre == name)
                {
                    Console.WriteLine("==================");
                    Console.WriteLine("Usuario encontrado con éxito");
                    Console.WriteLine($"Nombre: {paciente.Nombre}");
                    Console.WriteLine($"Edad: {paciente.Edad}");
                    Console.WriteLine($"Sintoma: {paciente.Sintomas}");
                    return;
                }
            }
            Console.WriteLine($"El paciente con el nombre {name}, no fue encontrado");
        }
    }
        
}


