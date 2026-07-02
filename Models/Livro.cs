using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraTech.Models
{
    public class Livro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o título do livro.")]
        [StringLength(150, ErrorMessage = "O título deve ter no máximo 150 caracteres.")]
        [Display(Name = "Título")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o autor.")]
        [StringLength(100, ErrorMessage = "O nome do autor deve ter no máximo 100 caracteres.")]
        [Display(Name = "Autor")]
        public string Autor { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o ano de publicação.")]
        [Range(1500, 2100, ErrorMessage = "Informe um ano válido.")]
        [Display(Name = "Ano de Publicação")]
        public int AnoPublicacao { get; set; }

        [Required(ErrorMessage = "Informe o ISBN.")]
        [StringLength(20, ErrorMessage = "O ISBN deve ter no máximo 20 caracteres.")]
        [Display(Name = "ISBN")]
        public string ISBN { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a editora.")]
        [StringLength(100, ErrorMessage = "A editora deve ter no máximo 100 caracteres.")]
        [Display(Name = "Editora")]
        public string Editora { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a quantidade de exemplares.")]
        [Range(1, 9999, ErrorMessage = "A quantidade deve ser maior que zero.")]
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        [StringLength(1000, ErrorMessage = "A sinopse deve ter no máximo 1000 caracteres.")]
        [Display(Name = "Sinopse")]
        public string Sinopse { get; set; } = string.Empty;

        [Url(ErrorMessage = "Informe uma URL válida.")]
        [Display(Name = "URL da Capa")]
        public string? CapaUrl { get; set; }

        [Required(ErrorMessage = "Selecione uma categoria.")]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public Categoria? Categoria { get; set; }
    }
}