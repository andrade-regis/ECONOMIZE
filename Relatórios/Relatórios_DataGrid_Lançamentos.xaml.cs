using System;
using ECONOMIZE.Auxiliar;
using System.Windows.Controls;

namespace ECONOMIZE.Relatórios
{
    /// <summary>
    /// Interação lógica para Relatórios_DataGrid_Lançamentos.xam
    /// </summary>
    public partial class Relatórios_DataGrid_Lançamentos : UserControl
    {
        public Relatórios_DataGrid_Lançamentos()
        {
            InitializeComponent();

            Refresh();
        }

        private void Refresh()
        {
            StackPanel_principal.Children.Clear();

            Relatórios_DataGrid_Lançamentos_Colunas Colunas = new Relatórios_DataGrid_Lançamentos_Colunas();
            StackPanel_principal.Children.Add(Colunas);

            foreach(Lançamento lançamento in Informações.HistóricosDeLançamentos)
            {
                if (lançamento.Visivel)
                {
                    Relatórios_DataGrid_Lançamentos_Linhas Linha = new Relatórios_DataGrid_Lançamentos_Linhas(lançamento);
                    StackPanel_principal.Children.Add(Linha);
                }
            }
        }
    }
}
