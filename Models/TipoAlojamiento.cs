using System.ComponentModel.DataAnnotations;

namespace AuroraTravelAgency.Models;

public enum TipoAlojamiento
{
    [Display(Name = "Estándar (hotel 3★)")]
    Estandar = 1,

    [Display(Name = "Confort (hotel 4★)")]
    Confort = 2,

    [Display(Name = "Premium (cabaña o iglú de cristal)")]
    Premium = 3
}

public static class TipoAlojamientoExtensions
{
    public static string NombreVisible(this TipoAlojamiento tipo) => tipo switch
    {
        TipoAlojamiento.Estandar => "Estándar (hotel 3★)",
        TipoAlojamiento.Confort => "Confort (hotel 4★)",
        TipoAlojamiento.Premium => "Premium (cabaña o iglú de cristal)",
        _ => tipo.ToString()
    };
}
