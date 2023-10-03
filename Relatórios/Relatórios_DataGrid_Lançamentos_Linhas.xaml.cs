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
            string valor = Abreviar_Valor(String.Format("{0:C}", Lançamento.Valor), out string toolTipValor);
            string descrição = Abreviar_Descrição(Lançamento.Descrição, out string tooltipDescrição);
            string conta = Abreviar_Conta(Lançamento.Conta, out string toolTipConta);            
           
            lbl_Descrição.Content = descrição == string.Empty ? "----" : descrição;
            if(tooltipDescrição != string.Empty)
            {
                lbl_Descrição.ToolTip = tooltipDescrição;
            }

            lbl_Conta.Content = conta == string.Empty ? "----" : conta;
            if (toolTipConta != string.Empty)
            {
                lbl_Conta.ToolTip = toolTipConta;
            }

            lbl_Valor.Content = valor;

            if(toolTipValor != string.Empty)
            {
                lbl_Valor.ToolTip = toolTipValor;
            }

            lbl_Data.Content = Lançamento.Data.ToShortDateString();

            if (Lançamento.Tipo == "Receita")
            {
                BitmapImage bitmapImage = new BitmapImage(new Uri("pack://application:,,,/ECONOMIZE;component/Imagens/receita.png", UriKind.RelativeOrAbsolute));
                imagem_tipoDeTransação.Source = bitmapImage;
            }
        }

        private string Abreviar_Descrição(string descrição, out string toolTip)
        {
            toolTip = string.Empty;

            if(descrição.Length > 80)
            {
                ToolTip = descrição;
                descrição = descrição.Substring(0, 75) + "...";
            }

            return descrição;
        }

        private string Abreviar_Conta(string conta, out string toolTip)
        {
            toolTip = string.Empty;

            if (conta.Length > 10)
            {
                toolTip = conta;
                conta = conta.Substring(0, 7) + "...";
            }

            return conta;
        }

        private string Abreviar_Valor(string valor, out string toolTip)
        {
            toolTip = string.Empty;

            if (valor.Length > 14)
            {
                toolTip = valor;
                valor = valor.Substring(0, 12) + "...";
            }

            return valor;
        }

        private void imagem_remover_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if((MessageBox.Show("Deseja remover a transação selecionada?","REMOVER TRANSAÇÃO",MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes))
            {
                Lançamento.Visivel = false;
                this.Grid_principal.Visibility = Visibility.Collapsed;
            }
        }
    }
}
