namespace PeliculasAPI.DTOs
{
    public class PeliculaActorDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Foto { get; set; }
        public string Personajes { get; set; } = null!;
    }
}
