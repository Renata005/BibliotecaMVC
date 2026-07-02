using System.ComponentModel.DataAnnotations;

namespace LibraTech.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome da categoria.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Informe a descrição da categoria.")]
        [StringLength(300, ErrorMessage = "A descrição deve ter no máximo 300 caracteres.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; } = string.Empty;
    }
}