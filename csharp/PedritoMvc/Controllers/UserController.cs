using Microsoft.AspNetCore.Mvc;
using PedritoMvc.Data;

namespace PedritoMvc.Controllers;

public class UserController : Controller

{
    private readonly MysqlDbContext _db;

    public UserController(MysqlDbContext db)
    {
        _db = db;
        
    }
    
    public IActionResult Index() // Listar
    {
        var users = _db.users.ToList();
        return View(users);
    }

    public IActionResult Details() // Ver uno
    {
        return View();
    }

    public IActionResult Create() // Crear
    {
        return View();
        
    }

    public IActionResult Edit() // Editar
    {
        return View();
    }

    public IActionResult Delete() // Eliminar
    {
        return View();
    }

    public IActionResult Store()
    {
        return View();
    }

    public IActionResult Update()
    {
        return View();
    }
}