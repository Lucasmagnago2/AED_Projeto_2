using System;
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

            ValorVenda = valorCusto + (valorCusto * margemLucro/100);
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
            if (Quantidade - qtd < 0)
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
            }
        }
        public double ValorTotalEmEstoque()
        {
            return Quantidade * ValorVenda;
        }

        public override string ToString()
        {
            return $"Id: {Id}\nNome: {Nome}\nQuantidade: {Quantidade}\nValor de Custo: R${ValorCusto}\nMargem de lucro: {MargemLucro}%\nValor de venda: R${ValorVenda.ToString("F2")}";
        }
    }
}
