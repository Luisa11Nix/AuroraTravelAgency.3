using AuroraTravelAgency.Models;
using AuroraTravelAgency.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AuroraTravelAgency.Controllers;

public class CotizacionController : Controller
{
    private readonly IDestinoRepositorio _destinos;
    private readonly ICotizacionRepositorio _cotizaciones;
    private readonly CotizadorService _cotizador;

    public CotizacionController(
        IDestinoRepositorio destinos,
        ICotizacionRepositorio cotizaciones,
        CotizadorService cotizador)
    {
        _destinos = destinos;
        _cotizaciones = cotizaciones;
        _cotizador = cotizador;
    }

    // GET: /Cotizacion/Crear?destinoId=2
    // Muestra el formulario vacío (opcionalmente con el destino preseleccionado).
    [HttpGet]
    public IActionResult Crear(int? destinoId)
    {
        var solicitud = new SolicitudCotizacion
        {
            DestinoId = destinoId,
            NumeroViajeros = 2,
            Noches = 7
        };

        CargarDestinos(solicitud.DestinoId);
        return View(solicitud);
    }

    // POST: /Cotizacion/Crear
    // Recibe el formulario, valida, calcula el precio y redirige al resultado.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Crear(SolicitudCotizacion solicitud)
    {
        var destino = solicitud.DestinoId.HasValue
            ? _destinos.ObtenerPorId(solicitud.DestinoId.Value)
            : null;

        if (solicitud.DestinoId.HasValue && destino is null)
        {
            ModelState.AddModelError(nameof(solicitud.DestinoId), "El destino seleccionado no existe.");
        }

        if (!ModelState.IsValid || destino is null)
        {
            CargarDestinos(solicitud.DestinoId);
            return View(solicitud);   // vuelve al formulario mostrando los errores
        }

        var cotizacion = _cotizador.Calcular(solicitud, destino);
        _cotizaciones.Guardar(cotizacion);

        // Patrón Post-Redirect-Get: evita reenviar el formulario al recargar la página
        return RedirectToAction(nameof(Resultado), new { id = cotizacion.Id });
    }

    // GET: /Cotizacion/Resultado/{guid}
    [HttpGet]
    public IActionResult Resultado(Guid id)
    {
        var cotizacion = _cotizaciones.ObtenerPorId(id);
        if (cotizacion is null)
        {
            return NotFound();
        }

        return View(cotizacion);
    }

    private void CargarDestinos(int? seleccionado)
    {
        ViewBag.Destinos = new SelectList(_destinos.ObtenerTodos(), "Id", "Nombre", seleccionado);
    }
}
