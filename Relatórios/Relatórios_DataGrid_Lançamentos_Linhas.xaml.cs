using System;
using ECONOMIZE.Auxiliar;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;

namespace ECONOMIZE.Relatórios
{
    /// <summary>
    /// Interação lógica para Relatórios_DataGrid_Lançamentos_Linhas.xam
    /// </summary>
    public partial class Relatórios_DataGrid_Lançamentos_Linhas : UserControl
    {
        public Lançamento Lançamento;

        internal Relatórios_DataGrid_Lançamentos_Linhas(Lançamento _lançamento)
        {
            InitializeComponent();

            Lançamento = _lançamento;

            preencherLançamento();
        }

        private void preencherLançamento()
        {
            lbl_Data.Content = Lançamento.Data.ToShortDateString();
            lbl_Descrição.Content = Lançamento.Descrição == string.Empty ? "----" : Lançamento.Descrição;
            lbl_Conta.Content = Lançamento.Conta == string.Empty ? "----" : Lançamento.Conta;
            lbl_Valor.Content = String.Format("{0:C}", Lançamento.Valor);
            
            if(Lançamento.Tipo == "Receita")
            {
                BitmapImage bitmapImage = new BitmapImage(new Uri("receita.png", UriKind.RelativeOrAbsolute));
                imagem_tipoDeTransação.Source = bitmapImage;
            }
        }

        private void imagem_remover_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if((MessageBox.Show("","",MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes))
            {
                this.Grid_principal.Visibility = Visibility.Collapsed;
            }
        }
    }
}
