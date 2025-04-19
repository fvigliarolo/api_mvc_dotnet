using System.ComponentModel.DataAnnotations;
using api_mvc.Models;

namespace api_mvc;
public class CategoriaInsert
{
    [Required]
    [Range(1, 100)]
    public int Id { get; set; } = 0;

    [Required]
    [MaxLength(50)]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string Descripcion { get; set; } = string.Empty;
}