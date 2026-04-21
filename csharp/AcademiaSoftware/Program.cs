List<string> tareasPendiente = new List<string>();

string message = (@"
Bienvenid@ al centro de entrenamiento técnico

1. Nivel 1: Suma y validación numérica
2. Nivel 2: Cálculo y condicionales
3. Nivel 3: Manipulación de Cadenas
4. Nivel 4: Operaciones Lógicas (Calculadora)
5. Nivel 5: Análisis Numérico (Listas de enteros)
6. Nivel 6: Gestión de Tareas (Listas de cadenas)
7. Nivel 7: Arreglos y Búsqueda
8. Nivel 8: Programación Orientada a Objetos (Clases)
9. Nivel 9: CRUD de Objetos (Listas de objetos)
10. Salir

Seleccione un nivel para iniciar:");


while (true)
{
    Console.WriteLine(message);
    int opcion = int.Parse(Console.ReadLine());
    switch (opcion)
    {
        case 1:
            int num1 = ValidadorInt("Ingresa el primer número a operar: ");
            int num2 = ValidadorInt("Ingresa el segundo número a operar");
            int resultado = num1 + num2;
            
            Console.WriteLine($"el resultado de la suma es: {resultado}"); 
            break;
        case 2:
            double nota1 = ValidadorDouble("Ingresa la primera clasificación: ");
            double nota2 = ValidadorDouble("Ingresa la segunda clasificación: ");
            double nota3 = ValidadorDouble("Ingresa la tercera clasificación: ");

            double promedio = Promedio(nota1,nota2, nota3); 
            Console.WriteLine($"El promedio es {promedio}");
            break;
        case 3:
            Console.Write("Ingresa tu nombre: ");
            string nombre = Console.ReadLine();
            
            Console.Write("Ingresa tu apellido: ");
            string apellido = Console.ReadLine();
            
            Console.WriteLine($"Hola {nombre} {apellido} bienvenido al himalaya!");
            break;
        case 4:
            double numero1 = ValidadorDouble("Ingrese el primer numero a operar: ");
            string operador = ValidadorOperador("Ingrese un operador (+, -, *, /): ");
            double numero2 = ValidadorDouble("Ingresar el segundo número a operar: ");
            
            Calculadora(numero1, numero2, operador);
            break;
        case 5:
            List<int> listaNumero = new List<int>();

            for (int i = 0; i <= 5; i++)
            {
                int numero = ValidadorInt("Ingresa un número: ");
                listaNumero.Add(numero);
            }
            
            operacionLista(listaNumero);
            
            break;
        case 6:
            
            Console.WriteLine(@"Seleccionar la opcion
1. Agregar Tarea
2. Ver tareas
3. Eliminar tarea");

            int op = int.Parse(Console.ReadLine());
            
            switch (op)
            {
                case 1:
                    Console.Write("Ingrese la tarea que desea agregar: ");
                    string tarea = Console.ReadLine();
                    tareasPendiente.Add(tarea);
                    break;
                case 2:
                    for (int i = 0; i < tareasPendiente.Count; i++)
                    {
                        Console.WriteLine($"{i}. {tareasPendiente[i]}");
                        
                    }
                    break;
                case 3:
                    int indice = ValidadorInt("Por favor indicar la tarea a eliminar por su indice: ");
                    
                    tareasPendiente.RemoveAt(indice);
                    Console.WriteLine("Tarea eliminar con exito");
                    break;
            }
            break;
        case 7:
            string[] ciudades = { "Bogota", "Medellin", "Pereira", "Armenia", "Quindio" };
            Console.Write("Ingresa la ciudad a buscar: ");
            string ciudad = Console.ReadLine().Trim().ToLower();

            if (ciudades.Contains(ciudad))
            {
                Console.WriteLine("Encontrada");
                
            }
            else
            {
                Console.WriteLine("No encontrada");
            }
            
            break;
        case 8:
            Console.Write("Opcion8...");
            break;
        case 9:
             Console.WriteLine("Opcion9...");
            break;
        case 10:
            Console.WriteLine("Hasta luego...");
            return;
        default:
            Console.WriteLine("Opción invalida...");
            break;
    }
    
}


int ValidadorInt(string mensaje)
{
    int numero;

    do
    {
        Console.Write(mensaje);
        
    } while (!int.TryParse(Console.ReadLine(), out numero));
    
    return numero;
}

//Validar double valido
double ValidadorDouble(string mensaje)
{
    double numero;
    
    do
    {
        Console.Write(mensaje);
        
    } while (!double.TryParse(Console.ReadLine(), out numero));

    return numero;
}

double Promedio(params double[] numeros)
{
    double suma = 0;
    
    foreach (var numero in numeros)
    {
        suma += numero;
    }

    return suma / numeros.Length;
}

string ValidadorOperador(string mensaje)
{
    string operador;
    string[] operadoresValidos = { "+", "-", "*", "/" };

    do
    {
        Console.WriteLine(mensaje);
        operador = Console.ReadLine();

    } while (!operadoresValidos.Contains(operador));

    return operador;
}



void Calculadora(double num1, double num2, string operador)
{
    switch (operador)
    {
        case "+":
            Console.WriteLine(num1 + num2);
            return;
        case "-":
            Console.WriteLine(num1 - num2);
            return;
        case "*":
            Console.WriteLine(num1 * num2);
            return;
        case "/":
            if (num2 == 0)
            {
                Console.WriteLine("No se puede dividir por cero");
                return;
            }
            Console.WriteLine(num1 / num2);
            return;
    }
}

void operacionLista(List<int> numeros)
{
    int suma = 0;
    int max = numeros[0];
    int min = numeros[0];
    
    foreach (var numero in  numeros)
    {
        suma += numero;
        if (numero > max)
        {
            max = numero;
        }

        if (numero < min)
        {
            min = numero;

        }

    }
    
    Console.WriteLine($"La suma total de los números es: {suma}");
    Console.WriteLine($"EL número mayor de la lista es: {max}");
    Console.WriteLine($"EL número menor de la lista es: {min}");
    
    
}