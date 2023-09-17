using ECONOMIZE.Relatórios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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

namespace ECONOMIZE
{
    /// <summary>
    /// Interação lógica para frmInício.xam
    /// </summary>
    public partial class frmInício : UserControl
    {
        private List<Lançamento> lançamentos;

        public frmInício()
        {
            InitializeComponent();

            lançamentos = new List<Lançamento>();

            Atualizar_DadosPorLançamentos();
        }

        private void Atualizar_DadosPorLançamentos()
        {
            Atualizar_Saldo();
            Atualizar_Gastos();
            Atualizar_Entradas();
            Atualizar_Saídas();
        }

        private void Atualizar_Saldo()
        {
            decimal valorSaldo = 0;

            for (int contador = 0; contador < lançamentos.Count; contador++)
            {
                if (lançamentos[contador].Data.Date <= DateTime.Now.Date)
                {
                    valorSaldo += lançamentos[contador].Valor;
                }
            }

            string valorFormatado = String.Format("{0:C}", valorSaldo).Replace("R$", "");

            FormatarValores(ref Lbl_Saldo_Valor, valorFormatado);
        }

        private void Atualizar_Gastos()
        {
            decimal valorGasto = 0;

            for (int contador = 0; contador < lançamentos.Count; contador++)
            {
                if (lançamentos[contador].Data.Date <= DateTime.Now.Date
                    && lançamentos[contador].Tipo == "Despesa")
                {
                    valorGasto += lançamentos[contador].Valor;
                }
            }

            string valorFormatado = String.Format("{0:C}", valorGasto).Replace("R$", "");

            FormatarValores(ref Lbl_Gastos_Valor, valorFormatado);
        }

        private void Atualizar_Entradas()
        {
            decimal valorEntrada = 0;

            for (int contador = 0; contador < lançamentos.Count; contador++)
            {
                if (lançamentos[contador].Tipo == "Receita")
                {
                    valorEntrada += lançamentos[contador].Valor;
                }
            }

            string valorFormatado = String.Format("{0:C}", valorEntrada).Replace("R$", "");

            FormatarValores(ref Lbl_Entradas_Valor, valorFormatado);

        }

        private void Atualizar_Saídas()
        {
            decimal valorSaídas = 0;

            for (int contador = 0; contador < lançamentos.Count; contador++)
            {
                if (lançamentos[contador].Tipo == "Despesa")
                {
                    valorSaídas += lançamentos[contador].Valor;
                }
            }

            string valorFormatado = String.Format("{0:C}", valorSaídas).Replace("R$", "");

            FormatarValores(ref Lbl_Saídas_Valor, valorFormatado);
        }

        private void FormatarValores(ref Label LabelValor, string valorFormatado)
        {
            if (valorFormatado.Length > 11)
            {
                LabelValor.ToolTip = valorFormatado;
                LabelValor.Content = valorFormatado.Substring(0, 9) + "...";
            }
            else
            {
                LabelValor.Content = valorFormatado;
            }
        }
    }
}
