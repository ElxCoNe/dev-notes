using GestionTranspoorte.Entities;
using GestionTransporte.Data;
using Microsoft.EntityFrameworkCore;
using GestionTranspoorte.UI;
using GestionTranspoorte.Services;

var db = new AstroNovaContext();
var astronautService = new AstronautService(db);



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



bool salir = false;

while (!salir)
{
    Console.WriteLine(menuPrincipal);
    int option = ConsoleHelper.IntValidator(optionMessage);

    switch (option)
    {

        // Crud astronauta
        case 1:
            Console.WriteLine(menuCrud);
            int optionAstronaut = ConsoleHelper.IntValidator(optionMessage);
            switch (optionAstronaut)
            {
                case 1: // Crear
                  astronautService.Create();
                  break;

                case 2: // Listar
                    astronautService.List();
                    break;

                case 3: // Actualizar
                    astronautService.Update();
                    break;

                case 4: // Eliminar
                    astronautService.Delete();
                    break;

                case 5:// Volver
                    break;
                default:
                    ConsoleHelper.ErrorMessage("Opcion invalida");
                    break;
            }
            break;

  
        // Crud ingeniero

        case 2:
            Console.WriteLine(menuCrud);
            int optionEngineer = ConsoleHelper.IntValidator(optionMessage);
            switch (optionEngineer)
            {
                case 1: // Crear
                    Console.Write("Nombre: ");
                    string engName = Console.ReadLine();
                    Console.Write("Apellido: ");
                    string engLastName = Console.ReadLine();
                    Console.Write("Especialidad (propulsión, sistemas, IA): ");
                    string specialty = Console.ReadLine();
                    int yearsExp = ConsoleHelper.IntValidator("Años de experiencia: ");

                    if (string.IsNullOrWhiteSpace(engName) || string.IsNullOrWhiteSpace(engLastName))
                    {
                        ConsoleHelper.ErrorMessage("El nombre y apellido no pueden estar vacíos");
                        break;
                    }
                    if (yearsExp < 0)
                    {
                        ConsoleHelper.ErrorMessage("Los años de experiencia no pueden ser negativos");
                        break;
                    }

                    db.Engineers.Add(new Engineer { Name = engName, LasName = engLastName, Speciality = specialty, ExperienceYears = yearsExp });
                    db.SaveChanges();
                    ConsoleHelper.SuccessMessage($"Ingeniero {engName} creado correctamente");
                    break;

                case 2: // Listar
                    var engineers = db.Engineers.ToList();
                    if (engineers.Count == 0)
                    {
                        ConsoleHelper.ErrorMessage("No hay ingenieros registrados"); 
                        break;
                    }
                    foreach (var engineer in engineers)
                        Console.WriteLine($"ID: {engineer.Id} | {engineer.Name} {engineer.LasName} | Especialidad: {engineer.Speciality} | Años: {engineer.ExperienceYears}");
                    break;

                case 3: // Actualizar
                    int idEngineer = ConsoleHelper.IntValidator("ID del ingeniero a actualizar: ");
                    var engineerDb = db.Engineers.Find(idEngineer);
                    
                    if (engineerDb == null)
                    {
                        ConsoleHelper.ErrorMessage($"ID {idEngineer} no existe");
                        break;
                    }

                    Console.WriteLine("1. Nombre  2. Apellido  3. Especialidad  4. Años experiencia");
                    int optUpdateEng = ConsoleHelper.IntValidator("Selecciona qué actualizar: ");
                    switch (optUpdateEng)
                    {
                        case 1:
                            Console.Write("Nuevo nombre: ");
                            string newName = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(newName))
                            {
                                ConsoleHelper.ErrorMessage("El nombre no debe estar vacio");
                                break;
                            }

                            engineerDb.Name = newName;
                            db.SaveChanges();
                            ConsoleHelper.SuccessMessage("Nombre actualizado correctamente");
                            break;
                        case 2:
                            Console.Write("Nuevo apellido: ");
                            string newLastName = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(newLastName))
                            {
                                ConsoleHelper.ErrorMessage("El apellido no debe estar vacio");
                                break;
                            }

                            engineerDb.LasName = newLastName;
                            db.SaveChanges();
                            ConsoleHelper.SuccessMessage("Apellido actualizado correctamente");
                            break;
                        case 3:
                            Console.Write("Nueva especialidad: ");
                            string newSpecialty = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(newSpecialty))
                            {
                                ConsoleHelper.ErrorMessage("El especialidad no debe estar vacio");
                                break;
                            }

                            engineerDb.Speciality = newSpecialty;
                            db.SaveChanges();
                            ConsoleHelper.SuccessMessage("Especialidad actualizada correctamente");
                            break;
                        case 4:
                            int newYears = ConsoleHelper.IntValidator("Nuevos años: ");
                            if (newYears < 0)
                            {
                                ConsoleHelper.ErrorMessage("Los años no pueden ser negativos"); 
                                break;
                            }
                            engineerDb.ExperienceYears = newYears;
                            db.SaveChanges();
                            ConsoleHelper.SuccessMessage("Años de experiencia actualizados correctamente");
                            break;
                        default:
                            ConsoleHelper.ErrorMessage("Opción no válida");
                            break;
                    }
                    break;

                case 4: // Eliminar
                    int idDeleteEngineer = ConsoleHelper.IntValidator("ID del ingeniero a eliminar: ");
                    var engineerDelete = db.Engineers.Find(idDeleteEngineer);
                    if (engineerDelete == null)
                    {
                        ConsoleHelper.ErrorMessage($"ID {idDeleteEngineer} no existe"); 
                        break;
                    }
                    db.Engineers.Remove(engineerDelete);
                    db.SaveChanges();
                    ConsoleHelper.SuccessMessage("Ingeniero eliminado correctamente");
                    break;

                case 5:
                    break;
            }
            break;


        // Cud nave
        case 3:
            Console.WriteLine(menuCrud);
            int optionShip = ConsoleHelper.IntValidator(optionMessage);
            switch (optionShip)
            {
                case 1: // Crear
                    Console.Write("Nombre de la nave: ");
                    string shipName = Console.ReadLine();
                    Console.Write("Modelo: ");
                    string model = Console.ReadLine();
                    int capacity = ConsoleHelper.IntValidator("Capacidad de tripulación: ");
                    Console.Write("Estado (operativa, en mantenimiento, retirada): ");
                    string shipStatus = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(shipName) || string.IsNullOrWhiteSpace(model))
                    {
                        ConsoleHelper.ErrorMessage("El nombre y modelo no pueden estar vacíos");
                        break;
                    }
                    if (capacity <= 0)
                    {
                        ConsoleHelper.ErrorMessage("La capacidad debe ser mayor a 0");
                        break;
                    }

                    db.Ships.Add(new Ship { Name = shipName, Model = model, TripulationCapacity = capacity, Status = shipStatus });
                    db.SaveChanges();
                    ConsoleHelper.SuccessMessage($"Nave {shipName} creada correctamente");
                    break;

                case 2: // Listar
                    var ships = db.Ships.ToList();
                    if (ships.Count == 0)
                    {
                        ConsoleHelper.ErrorMessage("No hay naves registradas"); 
                        break;
                    }
                    foreach (var ship in ships)
                        Console.WriteLine($"ID: {ship.Id} | {ship.Name} | Modelo: {ship.Model} | Capacidad: {ship.TripulationCapacity} | Estado: {ship.Status}");
                    break;

                case 3: // Actualizar
                    int idShip = ConsoleHelper.IntValidator("ID de la nave a actualizar: ");
                    var shipDb = db.Ships.Find(idShip);
                    if (shipDb == null)
                    {
                        ConsoleHelper.ErrorMessage($"ID {idShip} no existe");
                        break;
                    }

                    Console.WriteLine("1. Nombre  2. Modelo  3. Capacidad  4. Estado");
                    int optUpdateShip = ConsoleHelper.IntValidator("Selecciona qué actualizar: ");
                    switch (optUpdateShip)
                    {
                        case 1:
                            Console.Write("Nuevo nombre: ");
                            string newShipName = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(newShipName))
                            {
                                ConsoleHelper.ErrorMessage("El nombre no puede estar vacio");
                                break;
                            }

                            shipDb.Name = newShipName;
                            db.SaveChanges();
                            ConsoleHelper.SuccessMessage("Nombre actualizado correctamente");
                            break;
                        case 2:
                            Console.Write("Nuevo modelo: ");
                            string newModel = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(newModel))
                            {
                                ConsoleHelper.ErrorMessage("El modelo no puede estar vacio");
                                break;
                            }

                            shipDb.Model = newModel;
                            db.SaveChanges();
                            ConsoleHelper.SuccessMessage("Modelo actualizado correctamente");
                            break;
                        case 3:
                            int newCapacity = ConsoleHelper.IntValidator("Nueva capacidad: ");
                            if (newCapacity <= 0)
                            {
                                ConsoleHelper.ErrorMessage("La capacidad debe ser mayor a 0"); 
                                break;
                            }
                            shipDb.TripulationCapacity = newCapacity;
                            db.SaveChanges();
                            ConsoleHelper.SuccessMessage("Capacidad actualizada correctamente");
                            break;
                        case 4:
                            Console.Write("Nuevo estado: ");
                            string newStatus = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(newStatus))
                            {
                                ConsoleHelper.ErrorMessage("El estado no puede estar vacio");
                                break;
                            }

                            shipDb.Status = newStatus;
                            db.SaveChanges();
                            ConsoleHelper.SuccessMessage("Estado actualizado correctamente");
                            break;
                        default:
                            ConsoleHelper.ErrorMessage("Opción no válida");
                            break;
                    }
                    break;

                case 4: // Eliminar
                    int idDeleteShip = ConsoleHelper.IntValidator("ID de la nave a eliminar: ");
                    var shipDelete = db.Ships.Find(idDeleteShip);
                    if (shipDelete == null)
                    {
                        ConsoleHelper.ErrorMessage($"ID {idDeleteShip} no existe");
                        break;
                    }
                    db.Ships.Remove(shipDelete);
                    db.SaveChanges();
                    ConsoleHelper.SuccessMessage("Nave eliminada correctamente");
                    break;

                case 5:
                    break;
            }
            break;


        // Cud misión

        case 4:
            Console.WriteLine(menuCrud);
            int optionMission = ConsoleHelper.IntValidator(optionMessage);
            switch (optionMission)
            {
                case 1: // Crear
                    Console.Write("Nombre de la misión: ");
                    string missionName = Console.ReadLine();
                    Console.Write("Fecha de lanzamiento (yyyy-MM-dd): ");
                    DateTime missionDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Estado (planificada, en curso, completada, fallida): ");
                    string missionStatus = Console.ReadLine();
                    int astronautId = ConsoleHelper.IntValidator("ID del astronauta: ");
                    int shipId = ConsoleHelper.IntValidator("ID de la nave: ");

                    // Verificar que el astronauta y la nave existen
                    var astronautMission = db.Astronauts.Find(astronautId);
                    var shipMission = db.Ships.Find(shipId);

                    if (astronautMission == null)
                    {
                        ConsoleHelper.ErrorMessage($"El astronauta con ID {astronautId} no existe"); 
                        break;
                    }

                    if (shipMission == null)
                    {
                        ConsoleHelper.ErrorMessage($"La nave con ID {shipId} no existe"); 
                        break;
                    }

                    db.Missions.Add(new Mission { MisionName = missionName, MissionDate = missionDate, Status = missionStatus, AstronautId = astronautId, ShipId = shipId });
                    db.SaveChanges();
                    ConsoleHelper.SuccessMessage($"Misión {missionName} creada correctamente");
                    break;

                case 2: // Listar
                    var missions = db.Missions
                        .Include(m => m.Astronaut)
                        .Include(m => m.Ship)
                        .ToList();
                    if (missions.Count == 0)
                    {
                        ConsoleHelper.ErrorMessage("No hay misiones registradas"); 
                        break;
                    }
                    foreach (var mission in missions)
                        Console.WriteLine($"ID: {mission.Id} | {mission.MisionName} | Fecha: {mission.MissionDate:yyyy-MM-dd} | Estado: {mission.Status} | Astronauta: {mission.Astronaut.Name} | Nave: {mission.Ship.Name}");
                    break;

                case 3: // Actualizar
                    int idMission = ConsoleHelper.IntValidator("ID de la misión a actualizar: ");
                    var missionDb = db.Missions.Find(idMission);
                    if (missionDb == null)
                    {
                        ConsoleHelper.ErrorMessage($"ID {idMission} no existe"); 
                        break;
                    }

                    Console.WriteLine("1. Nombre  2. Fecha  3. Estado");
                    int optUpdateMission = ConsoleHelper.IntValidator("Selecciona qué actualizar: ");
                    switch (optUpdateMission)
                    {
                        case 1:
                            Console.Write("Nuevo nombre: ");
                            
                            string newName = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(newName))
                            {
                                ConsoleHelper.ErrorMessage("El nombre no puede estar vacío");
                                break;
                            }

                            missionDb.MisionName = newName;
                            db.SaveChanges();
                            ConsoleHelper.SuccessMessage("Nombre de misión actualizado correctamente");
                            break;
                        case 2:
                            Console.Write("Nueva fecha (yyyy-MM-dd): ");
                            missionDb.MissionDate = DateTime.Parse(Console.ReadLine());
                            db.SaveChanges();
                            ConsoleHelper.SuccessMessage("Fecha de misión actualizada correctamente");
                            break;
                        case 3:
                            Console.Write("Nuevo estado: ");
                            string newStatus =  Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(newStatus))
                            {
                                ConsoleHelper.ErrorMessage("El estado no puede estar vacío");
                                break;
                            }

                            missionDb.Status = newStatus;
                            db.SaveChanges();
                            ConsoleHelper.SuccessMessage("Estado de misión actualizado correctamente");
                            break;
                        default:
                            ConsoleHelper.ErrorMessage("Opción no válida");
                            break;
                    }
                    break;

                case 4: // Eliminar
                    int idDeleteMission = ConsoleHelper.IntValidator("ID de la misión a eliminar: ");
                    var missionDelete = db.Missions.Find(idDeleteMission);
                    if (missionDelete == null)
                    {
                        ConsoleHelper.ErrorMessage($"ID {idDeleteMission} no existe");
                        break;
                    }
                    db.Missions.Remove(missionDelete);
                    db.SaveChanges();
                    ConsoleHelper.SuccessMessage("Misión eliminada correctamente");
                    break;

                case 5:
                    break;
            }
            break;
        
        // Crud exploration

        case 5:
            Console.WriteLine(menuCrud);
            int optionLog = ConsoleHelper.IntValidator(optionMessage);
            switch (optionLog)
            {
                case 1: // Crear
                    Console.Write("Planeta destino: ");
                    string planet = Console.ReadLine();
                    Console.Write("Descripción: ");
                    string description = Console.ReadLine();
                    Console.Write("Nivel de riesgo (bajo, medio, alto): ");
                    string riskLevel = Console.ReadLine();
                    int missionId = ConsoleHelper.IntValidator("ID de la misión: ");

                    var missionLog = db.Missions.Find(missionId);
                    if (missionLog == null)
                    {
                        ConsoleHelper.ErrorMessage($"La misión con ID {missionId} no existe"); 
                        break;
                    }

                    if (string.IsNullOrWhiteSpace(planet))
                    {
                        ConsoleHelper.ErrorMessage("El planeta destino no puede estar vacío");
                        break;
                    }

                    db.ExplorationLogs.Add(new ExplorationLog { PlanetDestiny = planet, Description = description, Status = riskLevel, MissionId = missionId });
                    db.SaveChanges();
                    ConsoleHelper.SuccessMessage($"Registro de exploración hacia {planet} creado correctamente");
                    break;

                case 2: // Listar
                    var logs = db.ExplorationLogs
                        .Include(r => r.Mission)
                        .ToList();
                    if (logs.Count == 0) { ConsoleHelper.ErrorMessage("No hay registros de exploración"); break; }
                    foreach (var log in logs)
                        Console.WriteLine($"ID: {log.Id} | Planeta: {log.PlanetDestiny} | Riesgo: {log.Status} | Misión: {log.Mission.MisionName}");
                    break;

                case 3: // Actualizar
                    int idLog = ConsoleHelper.IntValidator("ID del registro a actualizar: ");
                    var logDb = db.ExplorationLogs.Find(idLog);
                    if (logDb == null)
                    {
                        ConsoleHelper.ErrorMessage($"ID {idLog} no existe");
                        break;
                    }

                    Console.WriteLine("1. Planeta  2. Descripción  3. Nivel de riesgo");
                    int optUpdateLog = ConsoleHelper.IntValidator("Selecciona qué actualizar: ");
                    switch (optUpdateLog)
                    {
                        case 1:
                            Console.Write("Nuevo planeta: ");
                            string newPlanet = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(newPlanet))
                            {
                                ConsoleHelper.ErrorMessage("El planeta no puede estar vacío");
                                break;
                            }
                            logDb.PlanetDestiny = newPlanet;
                            db.SaveChanges();
                            ConsoleHelper.SuccessMessage("Planeta actualizado correctamente");
                            break;
                        case 2:
                            Console.Write("Nueva descripción: ");
                            string newDescription = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(newDescription))
                            {
                                ConsoleHelper.ErrorMessage("La descripción no puede estar vacía");
                                break;
                            }
                            
                            logDb.Description = newDescription;
                            db.SaveChanges();
                            ConsoleHelper.SuccessMessage("Descripción actualizada correctamente");
                            break;
                        case 3:
                            Console.Write("Nuevo nivel de riesgo (bajo, medio, alto): ");
                            string newRiskLevel = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(newRiskLevel))
                            {
                                ConsoleHelper.ErrorMessage("El nivel de riesgo no puede estar vacío");
                                break;
                            }
                            logDb.Status = newRiskLevel;
                            db.SaveChanges();
                            ConsoleHelper.SuccessMessage("Nivel de riesgo actualizado correctamente");
                            break;
                            
                        default:
                            ConsoleHelper.ErrorMessage("Opción no válida");
                            break;
                    }
                    break;

                case 4: // Eliminar
                    int idDeleteLog = ConsoleHelper.IntValidator("ID del registro a eliminar: ");
                    var logDelete = db.ExplorationLogs.Find(idDeleteLog);
                    if (logDelete == null)
                    {
                        ConsoleHelper.ErrorMessage($"ID {idDeleteLog} no existe");
                        break;
                    }
                    db.ExplorationLogs.Remove(logDelete);
                    db.SaveChanges();
                    ConsoleHelper.SuccessMessage("Registro de exploración eliminado correctamente");
                    break;

                case 5:
                    break;
            }
            break;

        case 0:
            salir = true;
            ConsoleHelper.SuccessMessage("¡Hasta luego!");
            break;

        default:
            ConsoleHelper.ErrorMessage("Opción no válida, intenta de nuevo");
            break;
    }
}