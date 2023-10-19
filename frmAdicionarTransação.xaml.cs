using ECONOMIZE.Auxiliar;
using System;
using System.Windows;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Panels;

namespace ECONOMIZE
{
    /// <summary>
    /// Interação lógica para frmAdicionarTransação.xam
    /// </summary>
    public partial class frmAdicionarTransação : Window
    {
        public Lançamento _lançamento;

        private bool Adicionar = false;

        public frmAdicionarTransação()
        {
            InitializeComponent();

            Check_Despesa.IsChecked = true;
            Adicionar = true;
        }

        public frmAdicionarTransação(Lançamento Lançamento)
        {
            InitializeComponent();

            _lançamento = Lançamento;

            Button_Content_Adicionar.Content = "Atualizar";


            PreencherComponentes();
        }

        private void PreencherComponentes()
        {
            Masked_Data.Text = _lançamento.Data.ToShortDateString();
            TextBox_Descrição.Text = _lançamento.Descrição;
            TextBox_Conta.Text = _lançamento.Conta;
            Masked_Valor.Text = _lançamento.Valor.ToString().Replace("-", string.Empty).Replace(".", string.Empty);

            if (_lançamento.Tipo == "Receita")
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
            this.Close();
        }

        private void Button_Adicionar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!Validar())
                return;

            if (_lançamento == null)
            {
                _lançamento = new Lançamento();
                Informações.HistóricosDeLançamentos.Add(_lançamento);
            }

            _lançamento.Data = DateTime.Parse(Masked_Data.Text);
            _lançamento.Descrição = TextBox_Descrição.Text.Trim();
            _lançamento.Conta = TextBox_Conta.Text.Trim();
            _lançamento.Tipo = (bool)Check_Despesa.IsChecked ? "Despesa" : "Receita";
            if (_lançamento.Tipo == "Despesa")
            {
                Masked_Valor.Text = "-" + Masked_Valor.Text;
            }

            _lançamento.Valor = Decimal.Parse(Masked_Valor.Text.Trim().
                                              Replace("R$", string.Empty).
                                              Replace("_", string.Empty));

            this.Close();
        }

        private bool Validar()
        {
            #region Validar Data

            string data = Masked_Data.Text.Replace("_", "");

            if (data.Length != 10)
            {
                MessageBox.Show("A Data informada não é válida.", Label_Transação.Content.ToString(), MessageBoxButton.OK, MessageBoxImage.Stop);
                Masked_Data.Focus();
                return false;
            }

            try
            {
                DateTime DataTransação  = DateTime.Parse(data);
                DateTime DataAtual = DateTime.Now;

                if(DataTransação.Month != DataAtual.Month)
                {
                    MessageBox.Show("Data informada deve ser referente ao mês atual.", Label_Transação.Content.ToString(), MessageBoxButton.OK, MessageBoxImage.Stop);
                    Masked_Valor.Focus();
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Valor informado inválido.", Label_Transação.Content.ToString(), MessageBoxButton.OK, MessageBoxImage.Stop);
                Masked_Valor.Focus();
                return false;
            }

            #endregion

            #region Validar Descrição

            string descrição = TextBox_Descrição.Text;

            if (descrição.Trim().Length == 0 && descrição.Replace(" ", string.Empty).Length == 0)
            {
                MessageBox.Show("Obrigatório informar descrição de transação.", Label_Transação.Content.ToString(), MessageBoxButton.OK, MessageBoxImage.Stop);
                TextBox_Descrição.Focus();
                return false;
            }

            #endregion

            #region Validar Conta

            string conta = TextBox_Conta.Text;

            if (conta.Trim().Length == 0 && conta.Replace(" ", string.Empty).Length == 0)
            {
                MessageBox.Show("Obrigatório informar descrição de transação.", Label_Transação.Content.ToString(), MessageBoxButton.OK, MessageBoxImage.Stop);
                TextBox_Conta.Focus();
                return false;
            }

            #endregion

            #region Validar Valor

            string valor = Masked_Valor.Text.Trim().Replace("R$", string.Empty).Replace("_", string.Empty);

            if (valor.Length == 0)
            {
                MessageBox.Show("É obrigatório informar valor.", Label_Transação.Content.ToString(), MessageBoxButton.OK, MessageBoxImage.Stop);
                Masked_Valor.Focus();
                return false;
            }

            int virgulas = 0;

            foreach (char caracter in valor)
            {

                if (caracter == ',')
                {
                    virgulas++;
                }

                if (virgulas > 1)
                {
                    MessageBox.Show("A virgula só pode ser usada 1 vez.", Label_Transação.Content.ToString(), MessageBoxButton.OK, MessageBoxImage.Stop);
                    Masked_Valor.Focus();
                    return false;
                }

                if (!(char.IsDigit(caracter)) && caracter != ',')
                {
                    MessageBox.Show($"O caracter informado '{caracter}' não é permitido", Label_Transação.Content.ToString(), MessageBoxButton.OK, MessageBoxImage.Stop);
                    Masked_Valor.Focus();
                    return false;
                }
            }

            try
            {
                decimal valorConvertido = decimal.Parse(valor);
            }
            catch (Exception)
            {
                MessageBox.Show("Valor informado inválido.", Label_Transação.Content.ToString(), MessageBoxButton.OK, MessageBoxImage.Stop);
                Masked_Valor.Focus();
                return false;
            }

            #endregion

            #region Validar Tipo de Transação

            if (Check_Despesa.IsChecked == null && Check_Receita.IsChecked == null)
            {
                MessageBox.Show("Obrigatório informar 'Tipo de Despesa'.", Label_Transação.Content.ToString(), MessageBoxButton.OK, MessageBoxImage.Stop);
                return false;
            }

            if (!(bool)Check_Despesa.IsChecked && !(bool)Check_Receita.IsChecked)
            {
                MessageBox.Show("Obrigatório definir 'Tipo de Despesa'.", Label_Transação.Content.ToString(), MessageBoxButton.OK, MessageBoxImage.Stop);
                return false;
            }

            #endregion

            return true;
        }
    }
}
