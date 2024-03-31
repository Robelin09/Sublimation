using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library.Models;

public class Ventas
{
    [Key]
    public int VentaId { get; set; }

    [Required]
    public DateTime FechaRegistro { get; set; }

    [Required(ErrorMessage = "Debe seleccionar un Cliente!!")]
    [ForeignKey("ClienteId")]
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "Debe seleccionar un Usuario!!")]
    [ForeignKey("UsuarioId")]
    public int UsuarioId { get; set; }

    [Required(ErrorMessage = "Debe seleccionar un Servicio!!")]
    [ForeignKey("ServicioId")]
    public int ServicioId { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    [Range(1.00, double.MaxValue, ErrorMessage = "Debe ser mayor a 1.00")]
    public double MontoTotal { get; set; }

    [ForeignKey("VentaId")]
    public ICollection<VentasDetalle> VentasDetalle { get; set; } = new List<VentasDetalle>();
}
