using System.ComponentModel.DataAnnotations;

namespace LibraTech.Models
{
    public class Livro
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        public string Autor { get; set; } = string.Empty;

        public string Categoria { get; set; } = string.Empty;

        public int AnoPublicacao { get; set; }
    }
}