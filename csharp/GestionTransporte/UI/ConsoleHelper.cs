namespace GestionTranspoorte.UI;

public static class d
{
    public static void SuccessMessage(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{mensaje}");
        Console.ResetColor();
    }

    public static void ErrorMessage(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{mensaje}");
        Console.ResetColor();
    }
    
    public static int IntValidator(string message)
    {
        int numero;
        do
        {
            Console.Write(message);
        } while (!int.TryParse(Console.ReadLine(), out numero));
        return numero;
    }
}