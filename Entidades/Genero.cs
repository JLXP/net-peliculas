using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.Entidades;

public class Genero
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public required string Nombre { get; set; }
}
