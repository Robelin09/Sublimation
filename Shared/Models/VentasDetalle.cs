using System.ComponentModel.DataAnnotations;

namespace Library.Models;

public class VentasDetalle
{
    [Key]
    public int VentasDetalleId { get; set; }
    [Required(ErrorMessage = "Debe asignar una fecha estimada")]
    public DateTime FechaEstimadaEntrega { get; set; }

    [Required(ErrorMessage = "Debe Ingresar la Dirección")]
    public string? Direccion { get; set; }
    public bool ServicioGrua { get; set; }
    public bool Instalacion { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    [Range(1.00, float.MaxValue, ErrorMessage = "Debe ser mayor a 1.00")]
    public float Costo { get; set; }
}
