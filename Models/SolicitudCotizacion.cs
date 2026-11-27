using System.ComponentModel.DataAnnotations;

namespace AuroraTravelAgency.Models;


public class SolicitudCotizacion
{
    [Required(ErrorMessage = "Escribe tu nombre.")]
    [StringLength(80, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 80 caracteres.")]
    [Display(Name = "Nombre completo")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "Escribe tu correo electrónico.")]
    [EmailAddress(ErrorMessage = "El correo no tiene un formato válido.")]
    [Display(Name = "Correo electrónico")]
    public string Correo { get; set; } = string.Empty;

    [Required(ErrorMessage = "Selecciona un destino.")]
    [Display(Name = "Destino")]
    public int? DestinoId { get; set; }

    [Required(ErrorMessage = "Selecciona la fecha de salida.")]
    [FechaFutura]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Fecha de salida")]
    public DateTime? FechaViaje { get; set; }

    [Required(ErrorMessage = "Indica el número de viajeros.")]
    [Range(1, 10, ErrorMessage = "Pueden viajar entre 1 y 10 personas.")]
    [Display(Name = "Número de viajeros")]
    public int? NumeroViajeros { get; set; }

    [Required(ErrorMessage = "Indica el número de noches.")]
    [Range(3, 14, ErrorMessage = "La estadía debe ser de 3 a 14 noches.")]
    [Display(Name = "Noches de estadía")]
    public int? Noches { get; set; }

    [Display(Name = "Tipo de alojamiento")]
    public TipoAlojamiento Alojamiento { get; set; } = TipoAlojamiento.Estandar;

    [Display(Name = "Incluir tour nocturno de auroras")]
    public bool IncluyeTourAuroras { get; set; } = true;

    [StringLength(300, ErrorMessage = "Máximo 300 caracteres.")]
    [Display(Name = "Comentarios (opcional)")]
    public string? Comentarios { get; set; }
}
