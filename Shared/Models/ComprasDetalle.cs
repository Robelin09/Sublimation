using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class ComprasDetalle
{
    [Key]
    public int ComprasDetalleId { get; set; }
    [ForeignKey("InsumoId")]
    public int InsumoId { get; set; }
    [Required(ErrorMessage = "Debe especificar la cantidad a comprar")]
    [Range(5, int.MaxValue, ErrorMessage = "La cantidad minima de productos a comprar es 5")]
    public int Cantidad { get; set; }
    [Required(ErrorMessage = "Debe espesificar la cantidad a comprar")]
    [Range(1.00, float.MaxValue, ErrorMessage = "EL precio debe ser mayor que 1.00")]
    public float Precio { get; set; }
}
