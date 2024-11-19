using System.ComponentModel.DataAnnotations;

namespace AlmaRosa_Ap1_P2.Models;

public class Articulos
{
    [Key]
    public int ArticuloId { get; set; }

    [Required (ErrorMessage = "Este campo debe de ser obligatorio")]
    public string Descripcion { get; set; }
    [Required(ErrorMessage = "Este campo debe de ser obligatorio")]
    public decimal Costo { get; set; }
    [Required(ErrorMessage = "Este campo debe de ser obligatorio")]
    public decimal Precio { get; set; }
    [Required(ErrorMessage = "Este campo debe de ser obligatorio")]
    public decimal Existencia { get; set; }
}
