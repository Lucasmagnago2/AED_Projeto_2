using System;
using SmartManager.Entidades;
using SmartManager.Entidades.enums;
using System.Collections.Generic;

namespace SmartManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Funcionario> funcionarios = new List<Funcionario>();
            funcionarios.Add(new Gerente("Admin", 20, 11122233344L, "123456", Departamento.Vendas));
            Gerencia administracao = new Gerencia();
            administracao.Estoque.Add(new Produto(001, "Café", 2.74, 0.5, 120));
            administracao.Estoque.Add(new Produto(002, "Leite", 3.26, 0.6, 240));
            administracao.Estoque.Add(new Produto(003, "Arroz", 8.18, 0.4, 460));

            Console.WriteLine("------SmartManager------}");

            string situacaoLogin = EstadoLogin.Deslogado.ToString();
            Funcionario funcAtivo = new Funcionario();

            while (situacaoLogin == "Deslogado")
            {
                Console.Write("Login: ");
                int login = int.Parse(Console.ReadLine());
                Console.Write("Senha: ");
                string senha = Console.ReadLine();

                foreach (Funcionario func in funcionarios)
                {
                    if (func.Id == login && func.Senha == senha)
                    {
                        funcAtivo = func;
                        situacaoLogin = EstadoLogin.Logado.ToString();
                    }
                }

                Console.WriteLine("Usuário e/ou senha inválidos.");
                Console.WriteLine("Tente Novamente");
            }

            Console.WriteLine($"Bem vindo, {funcAtivo.Nome}");
            Console.WriteLine("1. Administração");
            Console.WriteLine("2. Vendas");
            Console.WriteLine("3. Configurações de usuário");
            Console.WriteLine("0. Sair");
            Console.WriteLine();

            int op = int.Parse(Console.ReadLine());

            while (op != 0)
            {
                Console.Write("Selecione uma opção: ");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }
            }

        }
    }
}
