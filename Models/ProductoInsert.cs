using System.ComponentModel.DataAnnotations;
using api_mvc.Models;

namespace api_mvc;

public class ProductoInsert
{
    [Required]
    [MaxLength(50)]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Descripcion { get; set; } = string.Empty;

    [Required]
    [Range(0, 10000)]
    public double Precio { get; set; } = 0;

    [Required]
    [Range(0, 10000)]
    public int Stock { get; set; } = 0;

    [Required]
    public Categoria Categoria { get; set; } = new Categoria();
}