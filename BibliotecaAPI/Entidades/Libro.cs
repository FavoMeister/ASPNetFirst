using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Entidades
{
    public class Libro
    {
        public int Id { get; set; }
        [Required]
        public required string Titulo { get; set; }
        public int AutorId { get; set; } //Foreign Key
        public Autor? Autor { get; set; } //  A 1 libro le corresponde un Autor
    }
}
