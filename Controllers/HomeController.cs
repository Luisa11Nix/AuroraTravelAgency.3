using System.Diagnostics;
using AuroraTravelAgency.Models;
using AuroraTravelAgency.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuroraTravelAgency.Controllers;

public class HomeController : Controller
{
    private readonly IDestinoRepositorio _destinos;

    public HomeController(IDestinoRepositorio destinos)
    {
        _destinos = destinos;
    }

    // GET: /
    public IActionResult Index()
    {
        return View(_destinos.ObtenerTodos());
    }

    // GET: /Home/Privacy
    public IActionResult Privacy()
    {
        return View();
    }

    // GET: /Home/Error
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
