using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManager.Entidades
{
    internal class Venda
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public DateTime Data { get; set; }
        public double Total { get; set; }

        public double CalcularTotal(Produto p, int qtd, double totalParcial)
        {
            return totalParcial += p.ValorVenda * qtd;

        }
    }
}
