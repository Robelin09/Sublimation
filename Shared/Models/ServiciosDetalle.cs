using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library.Models;

public class ServiciosDetalle
{
    [Key]
    public int ServiciosDetalleId { get; set; }

    [ForeignKey("InsumoId")]
    public int InsumoId { get; set; }

    [Required(ErrorMessage = "Debe especificar la cantidad a utilizar")]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad minima de productos a utilizar es 1")]
    public int Cantidad { get; set; }
}
