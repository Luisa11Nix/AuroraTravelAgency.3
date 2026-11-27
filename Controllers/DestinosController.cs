using AuroraTravelAgency.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuroraTravelAgency.Controllers;

public class DestinosController : Controller
{
    private readonly IDestinoRepositorio _destinos;

    public DestinosController(IDestinoRepositorio destinos)
    {
        _destinos = destinos;
    }

    // GET: /Destinos
    public IActionResult Index()
    {
        return View(_destinos.ObtenerTodos());
    }

    // GET: /Destinos/Detalle/2
    public IActionResult Detalle(int id)
    {
        var destino = _destinos.ObtenerPorId(id);
        if (destino is null)
        {
            return NotFound();
        }

        return View(destino);
    }
}
