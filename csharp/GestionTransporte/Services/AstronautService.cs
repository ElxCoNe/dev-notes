using GestionTransporte.Data;
using GestionTranspoorte.Entities;
using GestionTranspoorte.UI;

namespace GestionTranspoorte.Services;


public class AstronautService
{
    private readonly AstroNovaContext _db;
    public AstronautService(AstroNovaContext db)
    {
        _db = db;
    }
    
    public void Create()
    {
        Console.Write("Nombre: ");
        string name = Console.ReadLine();

        Console.Write("Apellido: ");
        string lastName = Console.ReadLine();

        Console.Write("Rango (novato, piloto, comandante): ");
        string rank = Console.ReadLine();
        
        int hoursExperience = ConsoleHelper.IntValidator("Horas de experiencia: ");

        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(rank))
        {
            ConsoleHelper.ErrorMessage("El nombre y apellido no pueden estar vacíos");
            return;
        }

        if (hoursExperience <= 0)
        {
            ConsoleHelper.ErrorMessage("Las horas de experiencia deben ser mayores a 0");
            return;
        }

        _db.Astronauts.Add(new Astronaut
        {
            Name = name,
            LastName = lastName,
            Rank = rank,
            ExperienceHour = hoursExperience
        });

        _db.SaveChanges();
        ConsoleHelper.SuccessMessage($"Astronauta {name} creado correctamente");
    }

    public void List()
    {
        var astronauts = _db.Astronauts.ToList();

        if (astronauts.Count == 0)
        {
            ConsoleHelper.ErrorMessage("No hay astronautas registrados");
            return;
        }

        foreach (var astronaut in astronauts)
        {
            Console.WriteLine($"ID: {astronaut.Id} | {astronaut.Name} {astronaut.LastName} | Rango: {astronaut.Rank} | Horas: {astronaut.ExperienceHour}");
        }
    }

    public void Update()
    {
        int idAstronaut = ConsoleHelper.IntValidator("ID del astronauta a actualizar: ");
        var astronautDb = _db.Astronauts.Find(idAstronaut);

        if (astronautDb == null)
        {
            ConsoleHelper.ErrorMessage($"ID {idAstronaut} no existe");
            return;
        }

        Console.WriteLine("1. Nombre  2. Apellido  3. Rango  4. Horas experiencia");
        int optUpdate = ConsoleHelper.IntValidator("Selecciona qué actualizar: ");

        switch (optUpdate)
        {
            case 1:
                Console.Write("Nuevo nombre: ");
                string newName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(newName))
                {
                    ConsoleHelper.ErrorMessage("El nombre no puede estar vacío");
                    return;
                }

                astronautDb.Name = newName;
                _db.SaveChanges();
                ConsoleHelper.SuccessMessage("Nombre actualizado correctamente");
                break;

            case 2:
                Console.Write("Nuevo apellido: ");
                string newLastName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(newLastName))
                {
                    ConsoleHelper.ErrorMessage("El apellido no puede estar vacío");
                    return;
                }

                astronautDb.LastName = newLastName;
                _db.SaveChanges();
                ConsoleHelper.SuccessMessage("Apellido actualizado correctamente");
                break;

            case 3:
                Console.Write("Nuevo rango: ");
                string newRank = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(newRank))
                {
                    ConsoleHelper.ErrorMessage("El rango no debe estar vacío");
                    return;
                }

                astronautDb.Rank = newRank;
                _db.SaveChanges();
                ConsoleHelper.SuccessMessage("Rango actualizado correctamente");
                break;

            case 4:
                int newHours = ConsoleHelper.IntValidator("Nuevas horas: ");

                if (newHours <= 0)
                {
                    ConsoleHelper.ErrorMessage("Las horas deben ser mayores a 0");
                    return;
                }

                astronautDb.ExperienceHour = newHours;
                _db.SaveChanges();
                ConsoleHelper.SuccessMessage("Horas de experiencia actualizadas correctamente");
                break;

            default:
                ConsoleHelper.ErrorMessage("Opción no válida");
                break;
        }
    }

    public void Delete()
    {
        int idDeleteAstronaut = ConsoleHelper.IntValidator("ID del astronauta a eliminar: ");
        var astronautDelete = _db.Astronauts.Find(idDeleteAstronaut);

        if (astronautDelete == null)
        {
            ConsoleHelper.ErrorMessage($"ID {idDeleteAstronaut} no existe");
            return;
        }

        _db.Astronauts.Remove(astronautDelete);
        _db.SaveChanges();
        ConsoleHelper.SuccessMessage("Astronauta eliminado correctamente");
    }
}