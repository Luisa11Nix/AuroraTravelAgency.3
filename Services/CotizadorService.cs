using AuroraTravelAgency.Models;

namespace AuroraTravelAgency.Services;

/// <summary>
/// Lógica de negocio: calcula el precio de un viaje a partir de la solicitud y el destino.
/// Está separada del controlador para que éste solo coordine.
/// </summary>
public class CotizadorService
{
    private const decimal RecargoTemporadaAlta = 0.20m;   // +20 % entre septiembre y marzo
    private const decimal DescuentoPorGrupo = 0.10m;      // -10 % desde 4 viajeros
    private const int ViajerosParaDescuento = 4;

    public Cotizacion Calcular(SolicitudCotizacion solicitud, Destino destino)
    {
        int viajeros = solicitud.NumeroViajeros.GetValueOrDefault(1);
        int noches = solicitud.Noches.GetValueOrDefault(3);
        DateTime fechaViaje = solicitud.FechaViaje.GetValueOrDefault(DateTime.Today.AddDays(1));

        decimal factorAlojamiento = solicitud.Alojamiento switch
        {
            TipoAlojamiento.Confort => 1.35m,
            TipoAlojamiento.Premium => 1.80m,
            _ => 1.00m
        };

        bool enTemporada = EsTemporadaDeAuroras(fechaViaje);

        decimal costoAlojamiento = destino.PrecioPorPersonaPorNoche * noches * viajeros * factorAlojamiento;
        decimal recargo = enTemporada ? costoAlojamiento * RecargoTemporadaAlta : 0m;
        decimal costoTour = solicitud.IncluyeTourAuroras ? destino.PrecioTourAuroras * viajeros : 0m;

        decimal subtotal = costoAlojamiento + recargo + costoTour;
        decimal descuento = viajeros >= ViajerosParaDescuento ? subtotal * DescuentoPorGrupo : 0m;

        return new Cotizacion
        {
            Nombre = solicitud.Nombre.Trim(),
            Correo = solicitud.Correo.Trim(),
            DestinoId = destino.Id,
            DestinoNombre = destino.Nombre,
            FechaViaje = fechaViaje,
            NumeroViajeros = viajeros,
            Noches = noches,
            Alojamiento = solicitud.Alojamiento,
            IncluyeTourAuroras = solicitud.IncluyeTourAuroras,
            Comentarios = solicitud.Comentarios?.Trim(),
            EnTemporadaAuroras = enTemporada,
            CostoAlojamiento = Math.Round(costoAlojamiento, 2),
            RecargoTemporada = Math.Round(recargo, 2),
            CostoTour = Math.Round(costoTour, 2),
            DescuentoGrupo = Math.Round(descuento, 2),
            Total = Math.Round(subtotal - descuento, 2)
        };
    }

    /// <summary>Temporada alta de auroras: de septiembre a marzo.</summary>
    public static bool EsTemporadaDeAuroras(DateTime fecha) =>
        fecha.Month >= 9 || fecha.Month <= 3;
}
