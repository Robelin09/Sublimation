using System.ComponentModel.DataAnnotations;

namespace Library.Models;

public class Servicios
{
    [Key]
    public int ServicioId { get; set; }
    public DateTime FechaRegistro { get; set; }

    [Required(ErrorMessage = "Debe completar este campo")]
    [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "El Nombre debe contener solo letras.")]
    public string? TipoServicio { get; set; }

    [Required(ErrorMessage = "Se requiere una breve Descripción del servicio")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    [Range(1.00, float.MaxValue, ErrorMessage = "Debe ser mayor a 1.00")]
    public float CostoServicio { get; set; }
}
