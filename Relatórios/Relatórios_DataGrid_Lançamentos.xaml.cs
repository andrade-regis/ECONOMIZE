using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ECONOMIZE.Relatórios
{
    /// <summary>
    /// Interação lógica para Relatórios_DataGrid_Lançamentos.xam
    /// </summary>
    public partial class Relatórios_DataGrid_Lançamentos : UserControl
    {
        private List<Lançamento> lançamentos;

        public Relatórios_DataGrid_Lançamentos(List<Lançamento> lst_lançamentos)
        {
            InitializeComponent();

            lançamentos = lst_lançamentos;

            PreencherGrid();
        }

        private void PreencherGrid()
        {
            Relatórios_DataGrid_Lançamentos_Colunas Colunas = new Relatórios_DataGrid_Lançamentos_Colunas();
            StackPanel_principal.Children.Add(Colunas);

            foreach (Lançamento lançamento in lançamentos)
            {
                if (lançamento.Visivel)
                {
                    Relatórios_DataGrid_Lançamentos_Linhas Linha = new Relatórios_DataGrid_Lançamentos_Linhas(lançamento);
                    StackPanel_principal.Children.Add(Linha);
                }
            }
        }
    }

    public class Lançamento
    {
        public DateTime Data { get; set; }
        public string Descrição { get; set; }
        public string Conta { get; set; }
        public Decimal Valor { get; set; }
        public string Tipo { get; set; }
        public bool Visivel { get; set; }

        Lançamento()
        {
            Descrição = string.Empty;
            Conta = string.Empty;
            Valor = 0;
            Tipo = string.Empty;
            Visivel = true;
        }

        ~Lançamento()
        {
            Descrição = string.Empty;
            Conta = string.Empty;
            Valor = 0;
            Tipo = string.Empty;
            Visivel = true;
        }
    }
}
