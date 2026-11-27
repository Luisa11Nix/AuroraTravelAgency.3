namespace AuroraTravelAgency.Models;

public class Destino
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string CiudadBase { get; set; } = string.Empty;
    public string ImagenUrl { get; set; } = string.Empty;
    public string ImagenAlt { get; set; } = string.Empty;
    public string ImagenAutor { get; set; } = string.Empty;
    public string ImagenLicencia { get; set; } = string.Empty;
    public string ImagenFuenteUrl { get; set; } = string.Empty;
    public string ClaseTema { get; set; } = string.Empty;
    public string Resumen { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string MejorEpoca { get; set; } = string.Empty;

    /// <summary>Precio por persona y por noche en dólares (USD), alojamiento estándar.</summary>
    public decimal PrecioPorPersonaPorNoche { get; set; }

    /// <summary>Precio por persona del tour nocturno de caza de auroras (USD).</summary>
    public decimal PrecioTourAuroras { get; set; }

    public List<string> LugaresAuroras { get; set; } = new();
    public List<string> Actividades { get; set; } = new();
}
