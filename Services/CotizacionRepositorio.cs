using System.Collections.Concurrent;
using AuroraTravelAgency.Models;

namespace AuroraTravelAgency.Services;

public interface ICotizacionRepositorio
{
    void Guardar(Cotizacion cotizacion);
    Cotizacion? ObtenerPorId(Guid id);
}

/// <summary>
/// Almacén en memoria de cotizaciones (se reinicia al reiniciar la aplicación).
/// ConcurrentDictionary es seguro cuando varios usuarios envían el formulario a la vez.
/// </summary>
public class CotizacionRepositorio : ICotizacionRepositorio
{
    private readonly ConcurrentDictionary<Guid, Cotizacion> _cotizaciones = new();

    public void Guardar(Cotizacion cotizacion) => _cotizaciones[cotizacion.Id] = cotizacion;

    public Cotizacion? ObtenerPorId(Guid id) =>
        _cotizaciones.TryGetValue(id, out var cotizacion) ? cotizacion : null;
}
