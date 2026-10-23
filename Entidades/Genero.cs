using System.ComponentModel.DataAnnotations;
using PeliculasAPI.Validaciones;

namespace PeliculasAPI.Entidades;

public class Genero
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(10, ErrorMessage = "El campo {0} debe tener {1} caracteres o menos")]
    [PrimeraLetraMayuscula]
    public required string Nombre { get; set; }
}
