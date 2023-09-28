using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECONOMIZE.Auxiliar
{
    public static class Informações
    {
        public static List<Lançamento> HistóricosDeLançamentos = new List<Lançamento>();
        public static decimal SaldoInicial = 0;
        public static decimal SaldoAtual = 0;
    }

    public class Lançamento
    {
        public int Indexador {  get; set; }
        public DateTime Data { get; set; }
        public string Descrição { get; set; }
        public string Conta { get; set; }
        public Decimal Valor { get; set; }
        public string Tipo { get; set; }
        public bool Visivel { get; set; }

        public Lançamento()
        {
            Indexador = 1;
            Descrição = string.Empty;
            Conta = string.Empty;
            Valor = 0;
            Tipo = string.Empty;
            Visivel = true;
        }

        ~Lançamento()
        {
            Indexador = 1;
            Descrição = string.Empty;
            Conta = string.Empty;
            Valor = 0;
            Tipo = string.Empty;
            Visivel = true;
        }
    }
}
