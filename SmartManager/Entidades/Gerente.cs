using System;
using System.Collections.Generic;
using SmartManager.Entidades.enums;

namespace SmartManager.Entidades
{
    internal class Gerente : Funcionario
    {

        public Gerente(string nome, int idade, long cpf, string senha, Departamento departamento) : base(nome, idade, cpf, senha, departamento)
        {

        }

       public void CadastrarFuncionario(List<Funcionario> lista,string nome, int idade, long cpf, string senha, Departamento departamento)
        {
            bool temCadastro = false;

            //Verificando se o funcionário já está cadastrado
            foreach(Funcionario f in lista)
            {
                if(f.Cpf == cpf)
                {
                    temCadastro = true;

                    Console.WriteLine();
                    Console.WriteLine("O cpf informado já possui cadastro no sistema");
                    Console.WriteLine();
                }
            }

            //Realizando o cadastro
            if (!temCadastro)
            {
                //Cadastro de gerente
                if (departamento == Departamento.Administração)
                {
                    lista.Add(new Gerente(nome, idade, cpf, senha, departamento));

                    Console.WriteLine();
                    Console.WriteLine("Funcionário cadastrado com sucesso");
                }
                //Cadastro de funcionário
                else
                {
                    lista.Add(new Vendedor(nome, idade, cpf, senha, departamento));

                    Console.WriteLine();
                    Console.WriteLine("Funcionário cadastrado com sucesso");
                }
            }
            
        }
        public void RemoverFuncionario(List<Funcionario> lista, long cpf)
        {
            //Procurando funcionario na lista e o removendo
            foreach (Funcionario f in lista)
            {
                //Removendo o funcionário da lista, caso ele seja encontrado
                if (f.Cpf == cpf)
                {
                    lista.Remove(f);

                    Console.WriteLine();
                    Console.WriteLine("Funcionário removido com sucesso");
                    Console.WriteLine();

                    return;
                }
            }

            //Caso funcionario não seja encontrado na lista
            Console.WriteLine();
            Console.WriteLine("Funcionário não encontrado");
            Console.WriteLine();

            return;
        }
        public void CadastrarProduto(List<Produto> listaDeProdutos, int id, string nome, double valorCusto, double margemLucro, int qtd)
        {
            bool jaCadastrado = false;

            //Verificando se o produto já está cadastrado
            foreach(Produto p in listaDeProdutos)
            {
                if(p.Id == id)
                {
                    jaCadastrado = true;

                    Console.WriteLine();
                    Console.WriteLine("Produto já cadastrado");
                    Console.WriteLine();

                    return;
                }
            }

            //Caso produto não esteja cadastrado, cria produto e adiciona na lista de produtos
            if (!jaCadastrado)
            {
                listaDeProdutos.Add(new Produto(id, nome, valorCusto, margemLucro, qtd));

                Console.WriteLine();
                Console.WriteLine("Produto cadastrado com sucesso");
                Console.WriteLine();
            }
        } 
        public override string ToString()
        {
            return $"Nome: {Nome}\nIdade: {Idade}\nCpf:{Cpf}\nDepartamento: {Departamento}";
        }
    }
}
