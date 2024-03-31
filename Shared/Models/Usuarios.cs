
using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Usuarios
{
    [Key]
    public int UsuarioId { get; set; }

    [Required(ErrorMessage = "El Nombre es un campo obligatorio.")]
    [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "El Nombre debe contener solo letras.")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "El Teléfono es un campo obligatorio.")]
    [StringLength(maximumLength: 10, MinimumLength = 10, ErrorMessage = "La longitud debe ser de 10 dígitos")]
    [RegularExpression("^[0-9]+$", ErrorMessage = "Solo puede contener caracteres num&eacute;ricos.")]
    public string? Telefono { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage = "La longitud debe ser de 11 dígitos")]
    [RegularExpression("^[0-9]+$", ErrorMessage = "Solo puede contener caracteres num&eacute;ricos.")]
    public string? Cedula { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Este campo es Obligatorio")]
    public string? Direccion { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public string? Cargo { get; set; }

    [Required]
    public DateTime FechaRegistro { get; set; }
}
