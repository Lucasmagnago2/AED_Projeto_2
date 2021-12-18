using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManager.Entidades
{
    internal class Administracao
    {
        public List<Produto> Estoque { get; set; } = new List<Produto>();
        public List<Venda> Vendas { get; set; } = new List<Venda>();

        public Administracao()
        {
 
        }

        public void RelatorioEstoque()
        {
            Console.WriteLine("---Estoque---");
            foreach(Produto p in Estoque)
            {
                Console.WriteLine($"Produto: {p.Nome}");
                Console.WriteLine($"Quantidade: {p.Quantidade}");
                Console.WriteLine($"Valor de custo: {p.ValorCusto.ToString("F2")}");
                Console.WriteLine($"Margem de lucro: {p.MargemLucro.ToString("F2")}");
                Console.WriteLine($"Valor de venda: {p.ValorTotalEmEstoque().ToString("F2")}");
            }
        }
        public void RelatorioVendas()
        {


        }

    }
}
