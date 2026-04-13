using GestionTranspoorte.Entities;
using GestionTransporte.Data;
using Microsoft.EntityFrameworkCore;

var db = new AstroNovaContext();

void SuccessMessage(string mensaje)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"{mensaje}");
    Console.ResetColor();
}

void ErrorMessage(string mensaje)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"{mensaje}");
    Console.ResetColor();
}

string menuPrincipal = @"
=== AstroNova Mission Control ===
1. Crud Astronauta
2. Crud Ingeniero
3. Crud Naves
4. Crud Misiones
5. Crud Registros de Exploración
0. Salir
";

string menuCrud = @"
1. Crear
2. Listar
3. Actualizar
4. Eliminar
5. Volver
";

string optionMessage = "Selecciona una opción: ";

int IntValidator(string message)
{
    int numero;
    do
    {
        Console.Write(message);
    } while (!int.TryParse(Console.ReadLine(), out numero));
    return numero;
}

bool salir = false;

while (!salir)
{
    Console.WriteLine(menuPrincipal);
    int option = IntValidator(optionMessage);

    switch (option)
    {

        // Crud astronauta
        case 1:
            Console.WriteLine(menuCrud);
            int optionAstronaut = IntValidator(optionMessage);
            switch (optionAstronaut)
            {
                case 1: // Crear
                    Console.Write("Nombre: ");
                    string name = Console.ReadLine() ?? string.Empty;
                    Console.Write("Apellido: ");
                    string lastName = Console.ReadLine() ?? string.Empty;
                    Console.Write("Rango (novato, piloto, comandante): ");
                    string rank = Console.ReadLine() ?? string.Empty;
                    int hoursExperience = IntValidator("Horas de experiencia: ");

                    if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(lastName))
                    {
                        ErrorMessage("El nombre y apellido no pueden estar vacíos");
                        break;
                    }
                    if (hoursExperience <= 0)
                    {
                        ErrorMessage("Las horas de experiencia deben ser mayores a 0");
                        break;
                    }

                    db.Astronauts.Add(new Astronaut { Name = name, LastName = lastName, Rank = rank, ExperienceHour = hoursExperience });
                    db.SaveChanges();
                    SuccessMessage($"Astronauta {name} creado correctamente");
                    break;

                case 2: // Listar
                    var astronauts = db.Astronauts.ToList();
                    if (astronauts.Count == 0)
                    {
                        ErrorMessage("No hay astronautas registrados"); 
                        break;
                    }
                    foreach (var astronaut in astronauts)
                        Console.WriteLine($"ID: {astronaut.Id} | {astronaut.Name} {astronaut.LastName} | Rango: {astronaut.Rank} | Horas: {astronaut.ExperienceHour}");
                    break;

                case 3: // Actualizar
                    int idAstronaut = IntValidator("ID del astronauta a actualizar: ");
                    var astronautDb = db.Astronauts.Find(idAstronaut);
                    if (astronautDb == null)
                    {
                        ErrorMessage($"ID {idAstronaut} no existe"); 
                        break;
                    }

                    Console.WriteLine("1. Nombre  2. Apellido  3. Rango  4. Horas experiencia");
                    int optUpdate = IntValidator("Selecciona qué actualizar: ");
                    switch (optUpdate)
                    {
                        case 1:
                            Console.Write("Nuevo nombre: ");
                            string newName = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(newName))
                            {
                                ErrorMessage("El nombre no puede estar vacío");
                                break;
                            }

                            astronautDb.Name = newName;
                            db.SaveChanges();
                            SuccessMessage("Nombre actualizado correctamente");
                            break;
                        case 2:
                            Console.Write("Nuevo apellido: ");
                            string newLastName = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(newLastName))
                            {
                                ErrorMessage("El apellido no puede estar vacío");
                                break;
                            }

                            astronautDb.LastName = newLastName;
                            db.SaveChanges();
                            SuccessMessage("Apellido actualizado correctamente");
                            break;
                        case 3:
                            Console.Write("Nuevo rango: ");
                            string newRank = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(newRank))
                            {
                                ErrorMessage("El rango no debe estar vacío");
                                break;
                            }
                            astronautDb.Rank = newRank;
                            db.SaveChanges();
                            SuccessMessage("Rango actualizado correctamente");
                            break;
                        
                        case 4:
                            int newHours = IntValidator("Nuevas horas: ");
                            if (newHours <= 0)
                            {
                                ErrorMessage("Las horas deben ser mayores a 0");
                                break;
                            }
                            astronautDb.ExperienceHour = newHours;
                            db.SaveChanges();
                            SuccessMessage("Horas de experiencia actualizadas correctamente");
                            break;
                        default:
                            ErrorMessage("Opción no válida");
                            break;
                    }
                    break;

                case 4: // Eliminar
                    int idDeleteAstronaut = IntValidator("ID del astronauta a eliminar: ");
                    var astronautDelete = db.Astronauts.Find(idDeleteAstronaut);
                    if (astronautDelete == null)
                    {
                        ErrorMessage($"ID {idDeleteAstronaut} no existe"); 
                        break;
                    }
                    db.Astronauts.Remove(astronautDelete);
                    db.SaveChanges();
                    SuccessMessage("Astronauta eliminado correctamente");
                    break;

                case 5:
                    break;
            }
            break;

  
        // Crud ingeniero

        case 2:
            Console.WriteLine(menuCrud);
            int optionEngineer = IntValidator(optionMessage);
            switch (optionEngineer)
            {
                case 1: // Crear
                    Console.Write("Nombre: ");
                    string engName = Console.ReadLine();
                    Console.Write("Apellido: ");
                    string engLastName = Console.ReadLine();
                    Console.Write("Especialidad (propulsión, sistemas, IA): ");
                    string specialty = Console.ReadLine();
                    int yearsExp = IntValidator("Años de experiencia: ");

                    if (string.IsNullOrWhiteSpace(engName) || string.IsNullOrWhiteSpace(engLastName))
                    {
                        ErrorMessage("El nombre y apellido no pueden estar vacíos");
                        break;
                    }
                    if (yearsExp < 0)
                    {
                        ErrorMessage("Los años de experiencia no pueden ser negativos");
                        break;
                    }

                    db.Engineers.Add(new Engineer { Name = engName, LasName = engLastName, Speciality = specialty, ExperienceYears = yearsExp });
                    db.SaveChanges();
                    SuccessMessage($"Ingeniero {engName} creado correctamente");
                    break;

                case 2: // Listar
                    var engineers = db.Engineers.ToList();
                    if (engineers.Count == 0)
                    {
                        ErrorMessage("No hay ingenieros registrados"); 
                        break;
                    }
                    foreach (var engineer in engineers)
                        Console.WriteLine($"ID: {engineer.Id} | {engineer.Name} {engineer.LasName} | Especialidad: {engineer.Speciality} | Años: {engineer.ExperienceYears}");
                    break;

                case 3: // Actualizar
                    int idEngineer = IntValidator("ID del ingeniero a actualizar: ");
                    var engineerDb = db.Engineers.Find(idEngineer);
                    
                    if (engineerDb == null)
                    {
                        ErrorMessage($"ID {idEngineer} no existe");
                        break;
                    }

                    Console.WriteLine("1. Nombre  2. Apellido  3. Especialidad  4. Años experiencia");
                    int optUpdateEng = IntValidator("Selecciona qué actualizar: ");
                    switch (optUpdateEng)
                    {
                        case 1:
                            Console.Write("Nuevo nombre: ");
                            string newName = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(newName))
                            {
                                ErrorMessage("El nombre no debe estar vacio");
                                break;
                            }

                            engineerDb.Name = newName;
                            db.SaveChanges();
                            SuccessMessage("Nombre actualizado correctamente");
                            break;
                        case 2:
                            Console.Write("Nuevo apellido: ");
                            string newLastName = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(newLastName))
                            {
                                ErrorMessage("El apellido no debe estar vacio");
                                break;
                            }

                            engineerDb.LasName = newLastName;
                            db.SaveChanges();
                            SuccessMessage("Apellido actualizado correctamente");
                            break;
                        case 3:
                            Console.Write("Nueva especialidad: ");
                            string newSpecialty = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(newSpecialty))
                            {
                                ErrorMessage("El especialidad no debe estar vacio");
                                break;
                            }

                            engineerDb.Speciality = newSpecialty;
                            db.SaveChanges();
                            SuccessMessage("Especialidad actualizada correctamente");
                            break;
                        case 4:
                            int newYears = IntValidator("Nuevos años: ");
                            if (newYears < 0) { ErrorMessage("Los años no pueden ser negativos"); break; }
                            engineerDb.ExperienceYears = newYears;
                            db.SaveChanges();
                            SuccessMessage("Años de experiencia actualizados correctamente");
                            break;
                        default:
                            ErrorMessage("Opción no válida");
                            break;
                    }
                    break;

                case 4: // Eliminar
                    int idDeleteEngineer = IntValidator("ID del ingeniero a eliminar: ");
                    var engineerDelete = db.Engineers.Find(idDeleteEngineer);
                    if (engineerDelete == null)
                    {
                        ErrorMessage($"ID {idDeleteEngineer} no existe"); 
                        break;
                    }
                    db.Engineers.Remove(engineerDelete);
                    db.SaveChanges();
                    SuccessMessage("Ingeniero eliminado correctamente");
                    break;

                case 5:
                    break;
            }
            break;


        // Cud nave
        case 3:
            Console.WriteLine(menuCrud);
            int optionShip = IntValidator(optionMessage);
            switch (optionShip)
            {
                case 1: // Crear
                    Console.Write("Nombre de la nave: ");
                    string shipName = Console.ReadLine();
                    Console.Write("Modelo: ");
                    string model = Console.ReadLine();
                    int capacity = IntValidator("Capacidad de tripulación: ");
                    Console.Write("Estado (operativa, en mantenimiento, retirada): ");
                    string shipStatus = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(shipName) || string.IsNullOrWhiteSpace(model))
                    {
                        ErrorMessage("El nombre y modelo no pueden estar vacíos");
                        break;
                    }
                    if (capacity <= 0)
                    {
                        ErrorMessage("La capacidad debe ser mayor a 0");
                        break;
                    }

                    db.Ships.Add(new Ship { Name = shipName, Model = model, TripulationCapacity = capacity, Status = shipStatus });
                    db.SaveChanges();
                    SuccessMessage($"Nave {shipName} creada correctamente");
                    break;

                case 2: // Listar
                    var ships = db.Ships.ToList();
                    if (ships.Count == 0)
                    {
                        ErrorMessage("No hay naves registradas"); 
                        break;
                    }
                    foreach (var ship in ships)
                        Console.WriteLine($"ID: {ship.Id} | {ship.Name} | Modelo: {ship.Model} | Capacidad: {ship.TripulationCapacity} | Estado: {ship.Status}");
                    break;

                case 3: // Actualizar
                    int idShip = IntValidator("ID de la nave a actualizar: ");
                    var shipDb = db.Ships.Find(idShip);
                    if (shipDb == null)
                    {
                        ErrorMessage($"ID {idShip} no existe");
                        break;
                    }

                    Console.WriteLine("1. Nombre  2. Modelo  3. Capacidad  4. Estado");
                    int optUpdateShip = IntValidator("Selecciona qué actualizar: ");
                    switch (optUpdateShip)
                    {
                        case 1:
                            Console.Write("Nuevo nombre: ");
                            string newShipName = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(newShipName))
                            {
                                ErrorMessage("El nombre no puede estar vacio");
                                break;
                            }

                            shipDb.Name = newShipName;
                            db.SaveChanges();
                            SuccessMessage("Nombre actualizado correctamente");
                            break;
                        case 2:
                            Console.Write("Nuevo modelo: ");
                            string newModel = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(newModel))
                            {
                                ErrorMessage("El modelo no puede estar vacio");
                                break;
                            }

                            shipDb.Model = newModel;
                            db.SaveChanges();
                            SuccessMessage("Modelo actualizado correctamente");
                            break;
                        case 3:
                            int newCapacity = IntValidator("Nueva capacidad: ");
                            if (newCapacity <= 0)
                            {
                                ErrorMessage("La capacidad debe ser mayor a 0"); 
                                break;
                            }
                            shipDb.TripulationCapacity = newCapacity;
                            db.SaveChanges();
                            SuccessMessage("Capacidad actualizada correctamente");
                            break;
                        case 4:
                            Console.Write("Nuevo estado: ");
                            string newStatus = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(newStatus))
                            {
                                ErrorMessage("El estado no puede estar vacio");
                                break;
                            }

                            shipDb.Status = newStatus;
                            db.SaveChanges();
                            SuccessMessage("Estado actualizado correctamente");
                            break;
                        default:
                            ErrorMessage("Opción no válida");
                            break;
                    }
                    break;

                case 4: // Eliminar
                    int idDeleteShip = IntValidator("ID de la nave a eliminar: ");
                    var shipDelete = db.Ships.Find(idDeleteShip);
                    if (shipDelete == null)
                    {
                        ErrorMessage($"ID {idDeleteShip} no existe");
                        break;
                    }
                    db.Ships.Remove(shipDelete);
                    db.SaveChanges();
                    SuccessMessage("Nave eliminada correctamente");
                    break;

                case 5:
                    break;
            }
            break;


        // Cud misión

        case 4:
            Console.WriteLine(menuCrud);
            int optionMission = IntValidator(optionMessage);
            switch (optionMission)
            {
                case 1: // Crear
                    Console.Write("Nombre de la misión: ");
                    string missionName = Console.ReadLine();
                    Console.Write("Fecha de lanzamiento (yyyy-MM-dd): ");
                    DateTime missionDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Estado (planificada, en curso, completada, fallida): ");
                    string missionStatus = Console.ReadLine();
                    int astronautId = IntValidator("ID del astronauta: ");
                    int shipId = IntValidator("ID de la nave: ");

                    // Verificar que el astronauta y la nave existen
                    var astronautMission = db.Astronauts.Find(astronautId);
                    var shipMission = db.Ships.Find(shipId);

                    if (astronautMission == null)
                    {
                        ErrorMessage($"El astronauta con ID {astronautId} no existe"); 
                        break;
                    }

                    if (shipMission == null)
                    {
                        ErrorMessage($"La nave con ID {shipId} no existe"); 
                        break;
                    }

                    db.Missions.Add(new Mission { MisionName = missionName, MissionDate = missionDate, Status = missionStatus, AstronautId = astronautId, ShipId = shipId });
                    db.SaveChanges();
                    SuccessMessage($"Misión {missionName} creada correctamente");
                    break;

                case 2: // Listar
                    var missions = db.Missions
                        .Include(m => m.Astronaut)
                        .Include(m => m.Ship)
                        .ToList();
                    if (missions.Count == 0)
                    {
                        ErrorMessage("No hay misiones registradas"); 
                        break;
                    }
                    foreach (var mission in missions)
                        Console.WriteLine($"ID: {mission.Id} | {mission.MisionName} | Fecha: {mission.MissionDate:yyyy-MM-dd} | Estado: {mission.Status} | Astronauta: {mission.Astronaut.Name} | Nave: {mission.Ship.Name}");
                    break;

                case 3: // Actualizar
                    int idMission = IntValidator("ID de la misión a actualizar: ");
                    var missionDb = db.Missions.Find(idMission);
                    if (missionDb == null)
                    {
                        ErrorMessage($"ID {idMission} no existe"); 
                        break;
                    }

                    Console.WriteLine("1. Nombre  2. Fecha  3. Estado");
                    int optUpdateMission = IntValidator("Selecciona qué actualizar: ");
                    switch (optUpdateMission)
                    {
                        case 1:
                            Console.Write("Nuevo nombre: ");
                            
                            string newName = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(newName))
                            {
                                ErrorMessage("El nombre no puede estar vacío");
                                break;
                            }

                            missionDb.MisionName = newName;
                            db.SaveChanges();
                            SuccessMessage("Nombre de misión actualizado correctamente");
                            break;
                        case 2:
                            Console.Write("Nueva fecha (yyyy-MM-dd): ");
                            missionDb.MissionDate = DateTime.Parse(Console.ReadLine());
                            db.SaveChanges();
                            SuccessMessage("Fecha de misión actualizada correctamente");
                            break;
                        case 3:
                            Console.Write("Nuevo estado: ");
                            string newStatus =  Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(newStatus))
                            {
                                ErrorMessage("El estado no puede estar vacío");
                                break;
                            }

                            missionDb.Status = newStatus;
                            db.SaveChanges();
                            SuccessMessage("Estado de misión actualizado correctamente");
                            break;
                        default:
                            ErrorMessage("Opción no válida");
                            break;
                    }
                    break;

                case 4: // Eliminar
                    int idDeleteMission = IntValidator("ID de la misión a eliminar: ");
                    var missionDelete = db.Missions.Find(idDeleteMission);
                    if (missionDelete == null)
                    {
                        ErrorMessage($"ID {idDeleteMission} no existe");
                        break;
                    }
                    db.Missions.Remove(missionDelete);
                    db.SaveChanges();
                    SuccessMessage("Misión eliminada correctamente");
                    break;

                case 5:
                    break;
            }
            break;
        
        // Crud exploration

        case 5:
            Console.WriteLine(menuCrud);
            int optionLog = IntValidator(optionMessage);
            switch (optionLog)
            {
                case 1: // Crear
                    Console.Write("Planeta destino: ");
                    string planet = Console.ReadLine();
                    Console.Write("Descripción: ");
                    string description = Console.ReadLine();
                    Console.Write("Nivel de riesgo (bajo, medio, alto): ");
                    string riskLevel = Console.ReadLine();
                    int missionId = IntValidator("ID de la misión: ");

                    var missionLog = db.Missions.Find(missionId);
                    if (missionLog == null)
                    {
                        ErrorMessage($"La misión con ID {missionId} no existe"); 
                        break;
                    }

                    if (string.IsNullOrWhiteSpace(planet))
                    {
                        ErrorMessage("El planeta destino no puede estar vacío");
                        break;
                    }

                    db.ExplorationLogs.Add(new ExplorationLog { PlanetDestiny = planet, Description = description, Status = riskLevel, MissionId = missionId });
                    db.SaveChanges();
                    SuccessMessage($"Registro de exploración hacia {planet} creado correctamente");
                    break;

                case 2: // Listar
                    var logs = db.ExplorationLogs
                        .Include(r => r.Mission)
                        .ToList();
                    if (logs.Count == 0) { ErrorMessage("No hay registros de exploración"); break; }
                    foreach (var log in logs)
                        Console.WriteLine($"ID: {log.Id} | Planeta: {log.PlanetDestiny} | Riesgo: {log.Status} | Misión: {log.Mission.MisionName}");
                    break;

                case 3: // Actualizar
                    int idLog = IntValidator("ID del registro a actualizar: ");
                    var logDb = db.ExplorationLogs.Find(idLog);
                    if (logDb == null)
                    {
                        ErrorMessage($"ID {idLog} no existe");
                        break;
                    }

                    Console.WriteLine("1. Planeta  2. Descripción  3. Nivel de riesgo");
                    int optUpdateLog = IntValidator("Selecciona qué actualizar: ");
                    switch (optUpdateLog)
                    {
                        case 1:
                            Console.Write("Nuevo planeta: ");
                            string newPlanet = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(newPlanet))
                            {
                                ErrorMessage("El planeta no puede estar vacío");
                                break;
                            }
                            logDb.PlanetDestiny = newPlanet;
                            db.SaveChanges();
                            SuccessMessage("Planeta actualizado correctamente");
                            break;
                        case 2:
                            Console.Write("Nueva descripción: ");
                            string newDescription = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(newDescription))
                            {
                                ErrorMessage("La descripción no puede estar vacía");
                                break;
                            }
                            
                            logDb.Description = newDescription;
                            db.SaveChanges();
                            SuccessMessage("Descripción actualizada correctamente");
                            break;
                        case 3:
                            Console.Write("Nuevo nivel de riesgo (bajo, medio, alto): ");
                            string newRiskLevel = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(newRiskLevel))
                            {
                                ErrorMessage("El nivel de riesgo no puede estar vacío");
                                break;
                            }
                            logDb.Status = newRiskLevel;
                            db.SaveChanges();
                            SuccessMessage("Nivel de riesgo actualizado correctamente");
                            break;
                            
                        default:
                            ErrorMessage("Opción no válida");
                            break;
                    }
                    break;

                case 4: // Eliminar
                    int idDeleteLog = IntValidator("ID del registro a eliminar: ");
                    var logDelete = db.ExplorationLogs.Find(idDeleteLog);
                    if (logDelete == null)
                    {
                        ErrorMessage($"ID {idDeleteLog} no existe");
                        break;
                    }
                    db.ExplorationLogs.Remove(logDelete);
                    db.SaveChanges();
                    SuccessMessage("Registro de exploración eliminado correctamente");
                    break;

                case 5:
                    break;
            }
            break;

        case 0:
            salir = true;
            SuccessMessage("¡Hasta luego!");
            break;

        default:
            ErrorMessage("Opción no válida, intenta de nuevo");
            break;
    }
}