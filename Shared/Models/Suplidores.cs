using System.ComponentModel.DataAnnotations;

namespace Library.Models;

public class Suplidores
{
    [Key]
    public int SuplidorId { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Este campo no acepta digitos")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage = "La longitud debe ser de 11 dígitos")]
    [RegularExpression("^[0-9]+$", ErrorMessage = "Solo puede contener caracteres numéricos.")]
    public string? RNC { get; set; }

    [Required(ErrorMessage = "El Teléfono es un campo obligatorio.")]
    [StringLength(maximumLength: 10, MinimumLength = 10, ErrorMessage = "La longitud debe ser de 10 dígitos")]
    [RegularExpression("^[0-9]+$", ErrorMessage = "Solo puede contener caracteres numéricos.")]
    public string? Telefono { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "La Dirección es un campo obligatorio.")]
    [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = "La longitud de la dirección debe estar entre 5 y 100 caracteres.")]
    public string? Direccion { get; set; }

    public DateTime FechaRegistro { get; set; }
}
