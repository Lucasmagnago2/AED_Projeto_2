using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace SmartManager.Entidades
{
    internal class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double ValorCusto { get; private set;}
        public double MargemLucro { get; private set;}
        public double ValorVenda { get; private set; }
        public int Quantidade { get; private set; }

        public Produto(int id, string nome, double valorCusto, double margemLucro, int quantidade)
        {
            Id = id;
            Nome = nome;

            //Atribuindo os atributos abaixo através de uma função para que eles sejam validados antes de serem atribuidos
            AlterarMargemLucro(margemLucro);
            SetQuantidade(quantidade);
            AlterarValorCusto(valorCusto);
            AtualizarValorVenda();
        }
        public void SetQuantidade(int qtd)
        {
            if (qtd < 0)
            {
                throw new ExcecaoDoSistema("A quantidade não pode ser menor do que 0");
            }
            else
            {
                Quantidade = qtd;
            }
        }
        public void AlterarQuantidade(int qtd)
        {
            if (Quantidade + qtd < 0)
            {
                throw new ExcecaoDoSistema("A quantidade que se deseja remover é maior quantidade do produto em estoque");
            }
            else
            {
                Quantidade += qtd;
            }
        }
        public void AlterarValorCusto(double valor)
        {
            if (valor < 0)
            {
                throw new ExcecaoDoSistema("O valor de custo não pode ser menor do que 0");
            }
            else
            {
                ValorCusto = valor;

                //Atualizando o valor de venda
                AtualizarValorVenda();
            }
        }
        public void AlterarMargemLucro(double valor)
        {
            if (valor < 0)
            {
                throw new ExcecaoDoSistema("A margem de lucro não pode ser menor do que 0");
            }
            else
            {
                MargemLucro = valor;

                //Atualizando o valor de venda
                AtualizarValorVenda();
            }
        }
        public void AtualizarValorVenda()
        {
            ValorVenda = ValorCusto + (ValorCusto * MargemLucro/100);
        }
        public double ValorTotalEmEstoque()
        {
            return Quantidade * ValorVenda;
        }

        public static void AtualizarBaseDeProdutos(List<Produto> lista)
        {
            FileStream baseProdutos = new FileStream("C:\\Users\\Lucas\\desktop\\SmartManager\\SmartManager\\Arquivos\\produtos.txt", FileMode.Open, FileAccess.Write);
            StreamWriter swProdutos = new StreamWriter(baseProdutos);

            foreach (Produto p in lista)
            {
                string dadosProduto = $"{p.Id};{p.Nome};{p.ValorCusto};{p.MargemLucro};{p.Quantidade}";

                swProdutos.WriteLine(dadosProduto);
            }

            swProdutos.Close();
            baseProdutos.Close();
        }

        //Atualizando a lista de produtos com os dados da base de dados.
        public static void AtualizarListaDeProdutos(List<Produto> lista)
        {
            string[] produtos = File.ReadAllLines("C:\\Users\\Lucas\\desktop\\SmartManager\\SmartManager\\Arquivos\\produtos.txt");

            foreach (string prod in produtos)
            {
                string[] dadosProduto = prod.Split(";");

                int id = int.Parse(dadosProduto[0]);
                string nome = dadosProduto[1];
                double valorCusto = double.Parse(dadosProduto[2]);
                double margemLucro = double.Parse(dadosProduto[3]);
                int quantidade = int.Parse(dadosProduto[4]);

                lista.Add(new Produto(id, nome, valorCusto, margemLucro, quantidade));
            }
        }
        public override string ToString()
        {
            return $"Id: {Id}\nNome: {Nome}\nQuantidade: {Quantidade}\nValor de Custo: R${ValorCusto}\nMargem de lucro: {MargemLucro}%\nValor de venda: R${ValorVenda.ToString("F2")}";
        }
    }
}
