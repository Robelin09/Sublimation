﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Reclamos
{
    [Key]
    public int ReclamoId { get; set; }
    public DateTime FechaReclamo { get; set; }
    [Required(ErrorMessage = "Debe seleccionar una Factura.")]
    [ForeignKey("VentaId")]
    public int VentaId { get; set; }
    [ForeignKey("ClienteId")]
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "Se requiere una breve descripción del Reclamo.")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "Se requiere ingresar la Acción tomada.")]
    public string? AccionTomada { get; set; }
}
