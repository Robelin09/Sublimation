using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models;

public class VentasDetalle
{
    [Key]
    public int VentasDetalleId { get; set; }
    [Required(ErrorMessage = "Debe asignar una fecha estimada")]
    public DateTime FechaEstimadaEntrega { get; set; }

    public bool ServicioGrua { get; set; }
    public bool Instalacion { get; set; }

    [Required(ErrorMessage = "Debe seleccionar un Servicio!!")]
    [ForeignKey("ServicioId")]
    public int ServicioId { get; set; }

    [Required(ErrorMessage = "Debe especificar la cantidad a comprar")]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad minima de productos a comprar 1")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    [Range(1.00, float.MaxValue, ErrorMessage = "Debe ser mayor a 1.00")]
    public float Costo { get; set; }
}
