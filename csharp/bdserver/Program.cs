using bdserver.Data;
using bdserver.Entities;
using System;
using Microsoft.EntityFrameworkCore;

var db = new MysqlDbContext();

string menuPrincipal = @"--Sistema--
1.Crud compañias
2.Crud usuarios
0.Salir
";

string secondMenu = @"----
1. Crear
2. Listar
3. Actualizar
4. Eliminar
5. Ver por nombre
0. Volver
";

string message = "Por favor selecciona un opcion: ";

int intValidator(string message)
{
    int numero;
    do
    {
        Console.WriteLine(message);
        
    } while (!int.TryParse(Console.ReadLine(), out numero));
    return numero;
}



bool exit = false;       

while (!exit)
{
    Console.Write(menuPrincipal);
    int option = intValidator(message);

    switch (option)
    {
        case 1:
            bool volver = false;

            while (!volver)
            {
                Console.Write(secondMenu);
                int optionSecond = intValidator(message);

                switch (optionSecond)
                {
                    case 1:
                        Console.Write("Nombre compañia: ");
                        string name = Console.ReadLine();

                        Console.Write("Dirección compañia: ");
                        string address = Console.ReadLine();

                        db.companies.Add(new Company { Name = name, Address = address });
                        db.SaveChanges();
                        Console.WriteLine($"Compania {name} agregada correcta");
                        break;

                    case 2:
                        var companiesList = db.companies.ToList();

                        foreach (var company in companiesList)
                        {
                            Console.WriteLine($"Id: {company.Id}, Name: {company.Name}, Address: {company.Address}");
                        }

                        break;
                    case 3:
                        int id = intValidator("ID compañia a modificar: ");

                        var findCompany = db.companies.Find(id);

                        if (findCompany == null)
                        {
                            Console.WriteLine($"Compañia con {id} no existe");
                            break;
                        }
                        
                        Console.WriteLine("1. Name");
                        Console.WriteLine("2. Address");

                        int companyOption =  intValidator(message);
                        
                        switch (companyOption)
                        {
                            case 1:
                                Console.Write("Nuevo nombre: ");
                                findCompany.Name = Console.ReadLine();
                                db.SaveChanges();
                                Console.Write("Compañia modificada correctamente");
                                break;
                            case 2:
                                Console.Write("Nuevo Address: ");
                                findCompany.Address = Console.ReadLine();
                                db.SaveChanges();
                                Console.Write("Compañia modificada correctamente");
                                break;
                            default:
                                Console.WriteLine("Opcion no valida, vuelve a intentarlo nuevamente");
                                break;
                        }
                        break;
                    case 4:

                        int idDeleteCompany = intValidator("Id compañia a eliminar: ");
                        
                        var deleteCompany = db.companies.Find(idDeleteCompany);

                        if (deleteCompany != null)
                        {
                            db.companies.Remove(deleteCompany);
                            db.SaveChanges();
                            Console.WriteLine("Compañia eliminada correctamente");
                            return;
                        }
                        Console.Write("Compañia no encontrada, vuelve a intentarlo");
                        break;
                    case 5:
                        Console.Write("Ingrese el nombre de la compañia a buscar: ");
                        string nameCompany = Console.ReadLine();
                        
                        var sqlNameCompany = db.companies.FirstOrDefault(c => c.Name == nameCompany);

                        if (sqlNameCompany != null)
                        {
                            Console.Write($"Nombre: {sqlNameCompany.Name}, Addres: {sqlNameCompany.Address}");
                            
                        }
                        else
                        {
                            Console.Write($"Nombre: {nameCompany} no existe");
                        }
                        break;
                    case 0:
                        Console.Write("Hasta luego");
                        volver = true;
                        break;
                    default:
                        Console.Write("No existe una opción, vuelve a intentar");
                        break;
                }
            }
            break;
        case 2: 
            bool volver2 = false;
            while (!volver2)
            {
                Console.Write(secondMenu);
                int optionSecond = intValidator(message);

                switch (optionSecond)
                {
                    case 1:
                        Console.Write("Nombre: ");
                        string name = Console.ReadLine();
                        
                        Console.Write("Apellido: ");
                        string lastName = Console.ReadLine();
                        
                        db.users.Add(new User { Name = name, LastName = lastName });
                        db.SaveChanges();
                        Console.WriteLine($"User {name} agregado correcta");
                        break;
                    case 2:

                        var users = db.users.ToList();
                        
                        foreach (var user in users)
                        {
                            Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, LastName: {user.LastName}");
                            
                        }
                        break;
                    case 3:

                        int idUser = intValidator("Id usuario a actualizar: ");

                        var findUser = db.users.Find(idUser);
                        
                        if (idUser == null)
                        {
                            Console.WriteLine($"Compañia con {idUser} no existe");
                            break;
                        }
                        
                        Console.WriteLine("1. Name");
                        Console.WriteLine("2. LastName");

                        int companyOption =  intValidator(message);
                        
                        switch (companyOption)
                        {
                            case 1:
                                Console.Write("Nuevo nombre: ");
                                findUser.Name = Console.ReadLine();
                                db.SaveChanges();
                                Console.Write("Usuario modificada correctamente");
                                break;
                            case 2:
                                Console.Write("Nuevo Address: ");
                                findUser.LastName = Console.ReadLine();
                                db.SaveChanges();
                                Console.Write("Usuario modificada correctamente");
                                break;
                            default:
                                Console.WriteLine("Opcion no valida, vuelve a intentarlo nuevamente");
                                break;
                        }
                        break;
                    case 4:
                        int idDeleteUser = intValidator("Id usuario a eliminar: ");
                        var deleteUser = db.users.Find(idDeleteUser);

                        if (deleteUser != null)
                        {
                            db.users.Remove(deleteUser);
                            db.SaveChanges();
                            Console.WriteLine($"User {deleteUser.Name} eliminado correctamente");
                        }
                        else
                        {
                            Console.WriteLine($"User {deleteUser.Name} no existe");
                            
                        }
                        break;
                    case 5:
                        Console.Write("Nombre de usuario: ");
                        string nameUser = Console.ReadLine();
                        
                        var sqlNameUser = db.users.FirstOrDefault(u => u.Name == nameUser);
                        if (sqlNameUser != null)
                        {
                            db.users.Remove(sqlNameUser);
                            db.SaveChanges();
                            Console.WriteLine($"User {nameUser} eliminado correctamente");
                        }
                        else
                        {
                            Console.WriteLine($"User {nameUser} no existe");
                        }
                        break;
                    case 0:
                        volver2 = true;
                        Console.WriteLine("Hasta luego");
                        break;
                    default:
                        Console.Write("No existe una opción, vuelve a intentar");
                        break;
                }
                
            }
            break;
        case 0:
            Console.WriteLine("Hasta luego");
            exit = true;
            break;
    }
}