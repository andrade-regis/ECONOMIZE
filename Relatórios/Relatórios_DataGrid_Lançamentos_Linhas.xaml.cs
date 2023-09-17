using System;
using System.Collections.Generic;
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
    /// Interação lógica para Relatórios_DataGrid_Lançamentos_Linhas.xam
    /// </summary>
    public partial class Relatórios_DataGrid_Lançamentos_Linhas : UserControl
    {
        private Lançamento Lançamento;

        internal Relatórios_DataGrid_Lançamentos_Linhas(Lançamento _lançamento)
        {
            InitializeComponent();

            Lançamento = _lançamento;
        }

        private void preencherLançamento()
        {
            lbl_Data.Content = Lançamento.Data.ToShortDateString();
            lbl_Descrição.Content = Lançamento.Descrição;
            lbl_Conta.Content = Lançamento.Conta;
            lbl_Valor.Content = String.Format("{0:C}", Lançamento.Valor);
            
            if(Lançamento.Tipo == "Receita")
            {
                BitmapImage bitmapImage = new BitmapImage(new Uri("receita.png", UriKind.RelativeOrAbsolute));
                imagem_tipoDeTransação.Source = bitmapImage;
            }
        }
    }
}
