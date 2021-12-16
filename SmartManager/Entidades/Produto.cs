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
        public double ValorVenda { get; set; }
        public int Quantidade { get; set; }

        public Produto(int id, string nome, double valorCusto, double margemLucro, int quantidade)
        {
            Id = id;
            Nome = nome;
            ValorCusto = valorCusto;
            MargemLucro = margemLucro;
            Quantidade = quantidade;
            ValorVenda = valorCusto + (valorCusto * margemLucro);
        }

        public void AlterarValorCusto(double valor)
        {
            if (valor > 0)
            {
                ValorCusto = valor;
            }
        }
        public void AlterarMargemLucro(double valor)
        {
            if (valor > 0)
            {
                MargemLucro = valor;
            }
        }
        public double ValorTotalEmEstoque()
        {
            return Quantidade * ValorVenda;
        }
    }
}
