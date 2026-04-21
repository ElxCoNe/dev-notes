Console.WriteLine("Bienvenido a nuestra plataforma premium");
Console.WriteLine("Por favor ingresar la siguiente información: ");
Console.WriteLine("===============================================");

//Nombre
Console.Write("Por favor ingresa su nombre: ");
string nombre = Console.ReadLine();

//Edad
Console.Write("Por favor ingresa su edad: ");
int edad = int.Parse(Console.ReadLine());

//Ciudad
Console.Write("Por favor ingrese la ciudad en la que vive: ");
string ciudad = Console.ReadLine();

string clasificacion = "";
string acceso = "";
    
if (edad < 12)
{
    clasificacion = "Niño";
    acceso = "No permitido";
}
else if (edad >= 12 && edad <= 17)
{
    clasificacion = "Adolescente";
    acceso = "No permitido";
}
else if (edad >= 18)
{
    clasificacion = "Adulto";
    acceso = "Permitido";
}

Console.WriteLine(@$"Hola {nombre} desde {ciudad},
Tienes {edad} años y perteneces a la categoría: {clasificacion}");

Console.WriteLine($"Acceso: {acceso}");