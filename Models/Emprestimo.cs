using System.ComponentModel.DataAnnotations;

namespace LibraTech.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Selecione um livro.")]
        [Display(Name = "Livro")]
        public int LivroId { get; set; }

        public Livro? Livro { get; set; }

        [Required(ErrorMessage = "Selecione um usuário.")]
        [Display(Name = "Usuário")]
        public int UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }

        [Required(ErrorMessage = "Informe a data do empréstimo.")]
        [Display(Name = "Data do Empréstimo")]
        [DataType(DataType.Date)]
        public DateTime DataEmprestimo { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Informe a data de devolução.")]
        [Display(Name = "Data de Devolução")]
        [DataType(DataType.Date)]
        public DateTime DataDevolucao { get; set; }

        [Display(Name = "Devolvido")]
        public bool Devolvido { get; set; }
    }
}