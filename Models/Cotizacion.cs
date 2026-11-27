namespace AuroraTravelAgency.Models;


public class Cotizacion
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime FechaSolicitud { get; set; } = DateTime.Now;

    public string Nombre { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public int DestinoId { get; set; }
    public string DestinoNombre { get; set; } = string.Empty;
    public DateTime FechaViaje { get; set; }
    public int NumeroViajeros { get; set; }
    public int Noches { get; set; }
    public TipoAlojamiento Alojamiento { get; set; }
    public bool IncluyeTourAuroras { get; set; }
    public string? Comentarios { get; set; }

    public bool EnTemporadaAuroras { get; set; }

    public decimal CostoAlojamiento { get; set; }
    public decimal RecargoTemporada { get; set; }
    public decimal CostoTour { get; set; }
    public decimal DescuentoGrupo { get; set; }
    public decimal Total { get; set; }

    public DateTime FechaRegreso => FechaViaje.AddDays(Noches);
    public decimal TotalPorPersona => NumeroViajeros > 0 ? Math.Round(Total / NumeroViajeros, 2) : Total;
}
