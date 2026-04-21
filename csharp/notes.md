Formatos de impresión en C# 

**Inicializar proyecto en C#
dotnet new console -0 FirstProject

Console.WriteLine("Hello, world!"); 
Console.Write("Hello, "); 


**Interpolacion de caracteres

string name = "John";   
int age = 30;   
Console.WriteLine($"Hello, my name is {name} and I am {age} years old."); 

**String.Format
string name = "John";   
int age = 30;   
Console.WriteLine("Hello, my name is {0} and I am {1} years old.", name, age);  


*EStructuras de datos

**Array

Un array en C# es una estructura de datos de tamaño fijo, lo que significa que debes definir su tamaño desde el principio y no puedes agregar más elementos después. 

int[] numbers = new int[5];
numbers[0] = 10;   
int[] numbers = { 10, 20, 30, 40, 50 };  


**List

 una lista es dinámica y se ajusta según las necesidades, permitiéndote agregar o eliminar elementos en cualquier momento sin preocuparte por el tamaño inicial.
 
 List <int>  numbers  = new  List <int>  (); 
numbers.Add(10); 



**Métodos en C#

los métodos son bloques de código que realizan una tarea específica. Son fundamentales para organizar tu código, mantenerlo limpio y evitar la repetición de instrucciones. Un método puede aceptar parámetros, realizar operaciones y devolver un valor, o simplemente ejecutar una acción sin devolver nada. 

int Sum(int a, int b)
{ 
         return a + b; 
} 

Ejemplo de un método sin retorno (void)

void Greet(string name) 
Métodos en C#
{ 
     Console.WriteLine( $ " Hello, { name } ! " ); 
} 


estudiar indempotencia
interfaz
principios solid

