using System;
using ECONOMIZE.Auxiliar;
using System.Windows.Controls;
using System.Windows;
using System.Linq;

namespace ECONOMIZE.Relatórios
{
    /// <summary>
    /// Interação lógica para Relatórios_DataGrid_Lançamentos.xam
    /// </summary>
    public partial class Relatórios_DataGrid_Lançamentos : UserControl
    {
        frmInício frmInício;

        public Relatórios_DataGrid_Lançamentos(frmInício frmInício)
        {
            InitializeComponent();

            this.frmInício = frmInício;

            Refresh();
        }

        public void Refresh()
        {
            StackPanel_principal.Children.Clear();

            Relatórios_DataGrid_Lançamentos_Colunas Colunas = new Relatórios_DataGrid_Lançamentos_Colunas();
            StackPanel_principal.Children.Add(Colunas);

            foreach (Lançamento lançamento in Informações.HistóricosDeLançamentos)
            {
                Relatórios_DataGrid_Lançamentos_Linhas Linha = new Relatórios_DataGrid_Lançamentos_Linhas(lançamento, this);
                StackPanel_principal.Children.Add(Linha);

            }

            frmInício.Atualizar_DadosPorLançamentos();
        }
    }
}
