using System.Collections.Generic;

namespace LibraTech.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalLivros { get; set; }

        public int TotalUsuarios { get; set; }

        public int EmprestimosAtivos { get; set; }

        public int LivrosDisponiveis { get; set; }

        // Dados do gráfico
        public List<string> Categorias { get; set; } = new();

        public List<int> QuantidadePorCategoria { get; set; } = new();
    }
}