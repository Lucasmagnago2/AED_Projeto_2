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
            foreach(Produto p in Estoque)
            {
                Console.WriteLine();
                Console.WriteLine($"Id: {p.Id}");
                Console.WriteLine($"Produto: {p.Nome}");
                Console.WriteLine($"Quantidade: {p.Quantidade}");
                Console.WriteLine($"Valor de custo: R$ {p.ValorCusto.ToString("F2")}");
                Console.WriteLine($"Margem de lucro: {p.MargemLucro.ToString("F1")}%");
                Console.WriteLine($"Valor de venda: R$ {p.ValorVenda.ToString("F2")}");
                Console.WriteLine($"Valor de total em estoque: R$ {p.ValorTotalEmEstoque().ToString("F2")}");
            }
        }
        public void RelatorioVendas()
        {

            foreach (Venda v in Vendas)
            {
                Console.WriteLine();
                Console.WriteLine($"Id: {v.Id}");
                Console.WriteLine(v.ItensVendidos);
                Console.WriteLine($"Valor total: R$ {v.Total.ToString("F2")}");
                Console.WriteLine($"Vendedor: {v.NomeVendedor}");
                Console.WriteLine($"Data: {v.Data}");
            }
        }
        public void ExibirListaDeProdutos()
        {
            foreach(Produto p in Estoque)
            {
                Console.WriteLine();
                Console.WriteLine($"Id: {p.Id}");
                Console.WriteLine($"Produto: {p.Nome}");
                Console.WriteLine($"Quantidade: {p.Quantidade}");
                Console.WriteLine($"Valor de venda: R$ {p.ValorVenda.ToString("F2")}");
            }
        }

    }
}
