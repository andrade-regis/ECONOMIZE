using ECONOMIZE.Auxiliar;
using System.Windows;
using System.Windows.Input;

namespace ECONOMIZE
{
    /// <summary>
    /// Interação lógica para frmAdicionarTransação.xam
    /// </summary>
    public partial class frmAdicionarTransação : Window
    {
        public Lançamento _Lançamento;
        private bool Adicionar = false;

        public frmAdicionarTransação()
        {
            InitializeComponent();

            _Lançamento = new Lançamento();
            Adicionar = true;
        }

        public frmAdicionarTransação(Lançamento Lançamento)
        {
            InitializeComponent();

            _Lançamento = Lançamento;

            Button_Content_Adicionar.Content = "Atualizar";

            PreencherComponentes();
        }

        private void PreencherComponentes()
        {
            Masked_Data.Text = _Lançamento.Data.ToShortDateString();
            TextBox_Descrição.Text = _Lançamento.Descrição;
            TextBox_Conta.Text = _Lançamento.Conta;
            Masked_Valor.Text = _Lançamento.Valor.ToString("#,##");
            
            if(_Lançamento.Tipo == "Receita")
            {
                Check_Receita.IsChecked = true;
            }
            else
            {
                Check_Despesa.IsChecked = true;
            }
        }

        private void Check_Despesa_Checked(object sender, RoutedEventArgs e)
        {
            if (Check_Despesa.IsChecked == true)
            {
                Check_Receita.IsChecked = false;
                return;
            }
        }

        private void Check_Receita_Checked(object sender, RoutedEventArgs e)
        {
            if (Check_Receita.IsChecked == true)
            {
                Check_Despesa.IsChecked = false;
                return;
            }
        }

        private void Button_Cancelar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _Lançamento = null;
            this.Close();
        }

        private void Button_Adicionar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
