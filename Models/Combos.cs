﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AlmaRosa_Ap1_P2.Models;

public class Combos
{
    [Key]
    public int ComboId { get; set; }
    [Required(ErrorMessage = "Este campo debe de ser obligatorio")]
    public DateTime Fecha {  get; set; }
    [Required(ErrorMessage = "Este campo debe de ser obligatorio")]
    public string Descripcion { get; set; }
    [Required(ErrorMessage = "Este campo debe de ser obligatorio")]
    public decimal  Precio { get; set; }
    [Required(ErrorMessage = "Este campo debe de ser obligatorio")]
    public string Vendido { get; set; }
}
