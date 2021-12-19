using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace SmartManager.Entidades
{
    internal class Venda
    {
        public int Id { get; private set; }
        public string ItensVendidos { get; private set; }
        public string NomeVendedor {  get; private set; }
        public DateTime Data { get; private set; }
        public double Total { get; private set; }

        public Venda(string itensVendidos, string vendedor, DateTime data, double total)
        {
            //função que atribui um número aleatório a propriedade Id
            SetId();
            ItensVendidos = itensVendidos;
            NomeVendedor = vendedor;
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
        public static void AtualizarBaseDeVendas(List<Venda> lista)
        {
            FileStream baseVendas = new FileStream("C:\\Users\\Lucas\\desktop\\SmartManager\\SmartManager\\Arquivos\\vendas.txt", FileMode.Open, FileAccess.Write);
            StreamWriter swVendas = new StreamWriter(baseVendas);

            foreach (Venda v in lista)
            {
                string dadosVenda = $"{v.Id};{v.ItensVendidos};{v.NomeVendedor};{v.Data};{v.Total}";

                swVendas.WriteLine(dadosVenda);
            }

            swVendas.Close();
            baseVendas.Close();
        }

        //Atualizando a lista de produtos com os dados da base de dados.
        public static void AtualizarListaDeVendas(List<Venda> lista)
        {
            string[] vendas = File.ReadAllLines("C:\\Users\\Lucas\\desktop\\SmartManager\\SmartManager\\Arquivos\\vendas.txt");

            foreach (string venda in vendas)
            {
                string[] dadosVenda = venda.Split(";");

                int id = int.Parse(dadosVenda[0]);
                string itensVendidos = dadosVenda[1];
                string nomeVendedor = dadosVenda[2];
                DateTime data = DateTime.Parse(dadosVenda[3]);
                double total = double.Parse(dadosVenda[4]);

                lista.Add(new Venda(itensVendidos, nomeVendedor, data, total));
            }
        }
        public override string ToString()
        {
            return $"Id: {Id}\n{ItensVendidos}\nTotal: R${Total.ToString("F2")}\nVendedor: {NomeVendedor}\nData: {Data.ToShortDateString()}";
        }
    }
}
