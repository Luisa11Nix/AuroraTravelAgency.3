using System.ComponentModel.DataAnnotations;

namespace AuroraTravelAgency.Models;

public class FechaFuturaAttribute : ValidationAttribute
{
    public FechaFuturaAttribute()
    {
        ErrorMessage = "La fecha del viaje debe ser posterior a hoy.";
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateTime fecha && fecha.Date <= DateTime.Today)
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}
