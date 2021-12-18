using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManager.Entidades
{
    internal class Venda
    {
        public int Id { get; private set; }
        public Vendedor Vendedor { private get; set; }
        public DateTime Data { get; private set; }
        public double Total { get; private set; }

        public Venda(Vendedor vendedor, DateTime data, double total)
        {
            //função que atribui um número aleatório a propriedade Id
            SetId();
            Vendedor = vendedor;
            Data = data;
            Total = total;
        }
        public void SetId()
        {
            //gerador de nº aleatório
            Random random = new Random();

            //Atribuindo nº aleatório ao Id
            Id = random.Next(1, 100000);
        }
        public static double CalcularTotal(Produto p, int qtd, double totalParcial)
        {
            return totalParcial += p.ValorVenda * qtd;

        }
        public override string ToString()
        {
            return $"Id: {Id}\nTotal: R${Total.ToString("F2")}\nVendedor: {Vendedor.Nome}\nData: {Data.ToShortDateString()}";
        }
    }
}
