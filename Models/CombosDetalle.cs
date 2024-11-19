﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlmaRosa_Ap1_P2.Models;

public class CombosDetalle
{
    [Key]
    public int DetalleId { get; set; }
  
    public Combos? Combos { get; set; }
    [ForeignKey("Combos")]
    public int ComboId { get; set; }

    public Articulos? Articulos { get; set; }
    [ForeignKey("Articulos")]
    public int ArticuloId { get; set; }

    [Required(ErrorMessage = "Este campo debe de ser obligatorio")]
    public decimal Cantidad { get; set; }

    [Required(ErrorMessage = "Este campo debe de ser obligatorio")]
    public decimal Costo { get; set; }
}