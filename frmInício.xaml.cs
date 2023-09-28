using ECONOMIZE.Auxiliar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace ECONOMIZE
{
    /// <summary>
    /// Interação lógica para frmInício.xam
    /// </summary>
    public partial class frmInício : UserControl
    {
        public frmInício()
        {
            InitializeComponent();

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
            decimal valorTransações = Informações.HistóricosDeLançamentos
                                      .Where(lan => lan.Data <= DateTime.Now.Date)
                                      .ToList().Sum(x => x.Valor);

            Informações.SaldoAtual = Informações.SaldoInicial + valorTransações;

            string valorFormatado = String.Format("{0:C}", Informações.SaldoAtual).Replace("R$", "");

            LimitarValores(ref Lbl_Saldo_Valor, valorFormatado);
        }

        private void Atualizar_Gastos()
        {
            decimal valorGasto = Informações.HistóricosDeLançamentos
                         .Where(lan => lan.Data <= DateTime.Now.Date 
                         && lan.Tipo == "Despesa")
                         .ToList().Sum(x => x.Valor);

            string valorFormatado = String.Format("{0:C}", valorGasto).Replace("R$", "");

            LimitarValores(ref Lbl_Gastos_Valor, valorFormatado);
        }

        private void Atualizar_Entradas()
        {
            decimal valorEntrada = 0;

            valorEntrada = Informações.HistóricosDeLançamentos
                         .Where(lan => lan.Tipo == "Receita")
                         .ToList().Sum(x => x.Valor);        

            string valorFormatado = String.Format("{0:C}", valorEntrada).Replace("R$", "");

            LimitarValores(ref Lbl_Entradas_Valor, valorFormatado);

        }

        private void Atualizar_Saídas()
        {
            decimal valorSaídas = 0;

            valorSaídas = Informações.HistóricosDeLançamentos
                         .Where(lan => lan.Tipo == "Despesa")
                         .ToList().Sum(x => x.Valor);

            string valorFormatado = String.Format("{0:C}", valorSaídas).Replace("R$", "");

            LimitarValores(ref Lbl_Saídas_Valor, valorFormatado);
        }

        private void LimitarValores(ref Label LabelValor, string valorFormatado)
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
