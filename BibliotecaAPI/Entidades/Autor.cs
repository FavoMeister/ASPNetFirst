using System.ComponentModel.DataAnnotations;
using BibliotecaAPI.Validaciones;

namespace BibliotecaAPI.Entidades
{
    public class Autor
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(10, ErrorMessage = "Ël campo {0} debe conterner {1} caracteres o menos")]
        [PrimeraLetraMayuscula]
        public required string Nombre { get; set; }
        public List<Libro> Libros { get; set; } = new List<Libro>();

        /*[Range(18, 120)]
        public int Edad {  get; set; }

        [CreditCard]
        public string? TarjetaDeCredito { get; set; }

        [Url]
        public string? URL { get; set; }*/
    }
}
