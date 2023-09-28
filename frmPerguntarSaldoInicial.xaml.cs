using ECONOMIZE.Auxiliar;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace ECONOMIZE
{
    /// <summary>
    /// Interação lógica para frmPerguntarSaldoInicial.xam
    /// </summary>
    public partial class frmPerguntarSaldoInicial : Window
    {
        private int quantidadeErros;
        public bool AcessoLiberado;

        public frmPerguntarSaldoInicial()
        {
            InitializeComponent();

            AcessoLiberado = false;
            quantidadeErros = 0;
        }

        private void Button_Seguir_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AcessoLiberado = false;

            if (!Validar(out string mensagem))
            {
                quantidadeErros++;

                if (Validar_QuantidadeErros())
                {
                    this.Close();
                    return;
                }

                if (MessageBox.Show(mensagem, "Informe Inicial", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) != MessageBoxResult.Yes)
                {
                    this.Close();                    
                }

                return;
            }

            Informações.SaldoInicial = Convert.ToDecimal(TextBox_Valor.Text);
            AcessoLiberado = true;
            this.Close();
        }

        private bool Validar_QuantidadeErros()
        {
            return quantidadeErros > 3;
        }

        private bool Validar(out string mensagem)
        {
            try
            {
                mensagem = string.Empty;

                if (TextBox_Valor.Text.Length == 0)
                {
                    mensagem = "É obrigatório informar 'Saldo Inicial'.\n Tentar novamente?";
                    return false;
                }

                int virgulas = 0;

                foreach (char caracter in TextBox_Valor.Text)
                {

                    if (caracter == ',')
                    {
                        virgulas++;
                    }

                    if(virgulas > 1)
                    {
                        mensagem = $"A virgula só pode ser usada 1 vez no saldo.\n Tentar novamente?";
                        return false;
                    }

                    if (!(char.IsDigit(caracter)) && caracter != ',')
                    {
                        mensagem = $"O caracter informado '{caracter}' não é permitido.\n Tentar novamente?";
                        return false;
                    }
                }

                decimal valor = Convert.ToDecimal(TextBox_Valor.Text);

                if (valor <= 0)
                {
                    mensagem = "O 'Saldo Inicial' não pode ser um valor negativo.\n Tentar novamente?";
                    return false;
                }

                return true;
            }
            catch(Exception erro)
            {
                mensagem = erro.Message;
                return false;
            }            
        }
    }
}
