using System;
using SmartManager.Entidades;
using SmartManager.Entidades.enums;
using System.Collections.Generic;

namespace SmartManager
{
    //Exceção personalizada
    class ExcecaoDoSistema : Exception
    {
        public ExcecaoDoSistema(string erro) : base(erro)
        {

        }
    }
    internal class Program
    {
        public static Departamento Login(List<Funcionario> lista)
        {
            //Estado do login
            string situacaoLogin = EstadoLogin.Deslogado.ToString();

            //Departamento do funcionário
            Departamento departamento = new Departamento();

            //Solicitando e verificando login e senha do funcionario, o loop continuará enquanto não for
            //inserido um login e senha corretos
            while (situacaoLogin != EstadoLogin.Logado.ToString())
            {
                //Solicitando login e senha
                Console.WriteLine();
                Console.Write("Login (cpf): ");
                long login = long.Parse(Console.ReadLine());
                Console.Write("Senha: ");
                string senha = Console.ReadLine();

                //Verificando se existe algum funcionário com o login e senha correspondente
                foreach (Funcionario funcionario in lista)
                {
                    if (funcionario.Cpf == login && funcionario.Senha == senha)
                    {
                        //Apresentando mensagem de sucesso
                        Console.WriteLine();
                        Console.WriteLine("Login realizado com sucesso!");

                        //Armazenando o departamento do usuário
                        departamento = funcionario.Departamento;
                        //Mudando o estatus de login para sair do loop da funçáo
                        situacaoLogin = EstadoLogin.Logado.ToString();

                    }
                }

                //Aprensentado mensagem de falha no login caso login e senha não batam com
                //os funcionarios da lista
                if (situacaoLogin == EstadoLogin.Deslogado.ToString())
                {
                    Console.WriteLine();
                    Console.WriteLine("Senha ou usuário inválidos, tente novamente.");
                    Console.WriteLine();
                }

            }

            //Retornando o departamento do funcionario que efetuou o login
            return departamento;
        }

        //Menu Administração
        public static int MenuAdministracao()
        {
            Console.WriteLine();
            Console.WriteLine("1. Cadastrar produto");
            Console.WriteLine("2. Editar produto");
            Console.WriteLine("3. Relatório do estoque");
            Console.WriteLine("4. Relatório de vendas");
            Console.WriteLine("5. Cadastrar funcionário");
            Console.WriteLine("6. Redefinir senha");
            Console.WriteLine("7. Sair");
            Console.WriteLine();

            Console.Write("Selecione um opção: ");

            int opcao = int.Parse(Console.ReadLine());

            //Verificar se a opção escolhida é válida
            if (opcao < 1 || opcao > 7)
            {
                //Lançar erro caso opção escolhida seja inválida
                throw new ExcecaoDoSistema("A opção escolhida não é válida");
            }
            else
            {
                return opcao;
            }
        }

        static void Main(string[] args)
        {
            try
            {
                //Criando lista de funcionários
                List<Funcionario> funcionarios = new List<Funcionario>();

                //Senha inicial
                string senhaInicial = "12345";

                //Criando funcionário default(administrador)
                Gerente admin = new Gerente("Admin", 20, 12345678999L, senhaInicial, Departamento.Administração);
                funcionarios.Add(admin);

                //Criando o setor de administração
                Administracao administracao = new Administracao();

                //Adicionando produtos iniciais no estoque
                administracao.Estoque.Add(new Produto(001, "Café", 2.74, 50, 120));
                administracao.Estoque.Add(new Produto(002, "Leite", 3.26, 60, 240));
                administracao.Estoque.Add(new Produto(003, "Arroz", 8.18, 40, 460));

                //Iniciando o sistema
                Console.WriteLine("------SmartManager------");

                //Apresentando tela de login
                Departamento departamentoFuncionario = Login(funcionarios);

                Console.WriteLine();

                //Apresentando o sistema de administração
                if (departamentoFuncionario == Departamento.Administração)
                {

                    int opcao = -1;

                    while (opcao != 7)
                    {
                        Console.WriteLine();
                        Console.WriteLine("---Administração---");

                        //Chamar menu de administração e pegar opção escolhida do usuário
                        opcao = MenuAdministracao();

                        switch (opcao)
                        {
                            case 1:
                                //1. Cadastrar produto
                                Console.WriteLine();
                                Console.WriteLine("---Cadastrar produto---");
                                Console.WriteLine();

                                Console.Write("Quantos produtos você quer cadastrar? ");
                                int qtd = int.Parse(Console.ReadLine());
                                Console.WriteLine();

                                for (int i = 0; i < qtd; i++)
                                {
                                    //Solicitando os dados desse novo produto
                                    Console.WriteLine();
                                    Console.WriteLine($"Produto {i + 1}");
                                    Console.WriteLine();

                                    Console.Write("Id: ");
                                    int id = int.Parse(Console.ReadLine());

                                    Console.Write("Nome: ");
                                    string nome = Console.ReadLine();

                                    Console.Write("Quantidade: ");
                                    int quantidade = int.Parse(Console.ReadLine());

                                    Console.Write("Valor de custo: ");
                                    double valorCusto = double.Parse(Console.ReadLine());

                                    Console.Write("Margem de lucro (%): ");
                                    double margemLucro = double.Parse(Console.ReadLine());

                                    //Criando o produto e adicionando ele na lista de produtos
                                    administracao.Estoque.Add(new Produto(id, nome, valorCusto, margemLucro, quantidade));

                                    Console.WriteLine();
                                    Console.WriteLine("Produto adicionado com sucesso");
                                    Console.WriteLine();
                                }

                                Console.WriteLine("Cadastro de produtos finalizado");
                                Console.WriteLine();
                                break;

                            case 2:
                                //2. Editar produto
                                Console.WriteLine();
                                Console.WriteLine("---Editar produto---");
                                Console.WriteLine();

                                Console.Write("Digite o Id do produto: ");
                                int idProduto = int.Parse(Console.ReadLine());

                                //Procurando o produto na lista compativel com o Id fornecido
                                Produto produtoEditar = administracao.Estoque.Find(x => x.Id == idProduto);

                                Console.WriteLine();
                                Console.WriteLine("Produto a ser editado: ");
                                Console.WriteLine(produtoEditar);
                                Console.WriteLine();

                                Console.WriteLine("O que você deseja alterar? ");
                                Console.WriteLine();
                                Console.WriteLine("1. Quantidade");
                                Console.WriteLine("2. Valor de custo");
                                Console.WriteLine("3. Margem de lucro:");
                                Console.WriteLine();
                                Console.Write("> ");

                                switch (int.Parse(Console.ReadLine()))
                                {  
                                    case 1:
                                        //1. Quantidade
                                        Console.WriteLine();
                                        Console.Write("Digite a quantidade (+ adicionar / - remover): ");
                                        int qtdProduto = int.Parse(Console.ReadLine());

                                        produtoEditar.AlterarQuantidade(qtdProduto);

                                        Console.WriteLine();
                                        Console.WriteLine("Quantidade alterada com sucesso");
                                        Console.WriteLine();
                                        break;

                                    case 2:
                                        //2. Valor de custo
                                        Console.WriteLine();
                                        Console.Write("Digite o valor de custo: ");
                                        double valorCustoProduto = double.Parse(Console.ReadLine());

                                        produtoEditar.AlterarValorCusto(valorCustoProduto);

                                        Console.WriteLine();
                                        Console.WriteLine("Valor de custo alterado com sucesso");
                                        Console.WriteLine();
                                        break;
                                    case 3:
                                        //3. Margem de lucro
                                        Console.WriteLine();
                                        Console.Write("Digite o valor de custo: ");
                                        double margemLucroProduto = double.Parse(Console.ReadLine());

                                        produtoEditar.AlterarMargemLucro(margemLucroProduto);

                                        Console.WriteLine();
                                        Console.WriteLine("Margem de lucro alterada com sucesso");
                                        Console.WriteLine();
                                        break;
                                }                    
                                break;

                            case 3:
                                //3. Relatório do estoque
                                Console.WriteLine();
                                Console.WriteLine("---Relatório do Estoque---");
                                Console.WriteLine();

                                int ii = 0;

                                foreach(Produto p in administracao.Estoque)
                                {
                                    Console.WriteLine($"Produto {ii + 1}");
                                    Console.WriteLine(p);
                                    Console.WriteLine();

                                    ii++;
                                }

                                Console.WriteLine();
                                Console.WriteLine("---Fim do relatório---");
                                break;

                            case 4:
                                //4. Relatório de vendas

                                break;

                            case 5:
                                //5. Cadastrar funcionário
                                Console.WriteLine();
                                Console.WriteLine("---Cadastro de funcionários---");
                                Console.WriteLine();

                                Console.Write("Quantos funcionários você desenha cadastrar? ");
                                int qtdCadastro = int.Parse(Console.ReadLine());

                                for (int i = 0; i < qtdCadastro; i++)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine($"Cadastro {i + 1}");

                                    Console.Write("Nome: ");
                                    string nomeCadastro = Console.ReadLine();

                                    Console.Write("Idade: ");
                                    int idadeCadastro = int.Parse(Console.ReadLine());

                                    Console.Write("CPF: ");
                                    long cpfCadastro = long.Parse(Console.ReadLine());

                                    Console.Write("Departamento (1. Administração/2. Vendas): ");
                                    Departamento departamentoCadastro = Enum.Parse<Departamento>(Console.ReadLine());

                                    funcionarios.Add(new Funcionario(nomeCadastro, idadeCadastro, cpfCadastro, senhaInicial, departamentoCadastro));

                                    Console.WriteLine();
                                    Console.WriteLine("Funcionário cadastrado com sucesso!");
                                }
                                break;

                                Console.WriteLine();
                                Console.WriteLine("---Fim do cadastro de funcionários---");

                            case 6:
                                //6. Alterar senha
                                Console.WriteLine();
                                Console.WriteLine("---Alterar senha---");
                                Console.WriteLine();

                                Console.Write("Digite uma nova senha (a senha tem que ter ao menos 5 digitos): ");

                                //Alterando a senha do funcionário

                                break;

                            case 7:
                                //7. Sair

                                //Encerrando o loop do sistema da Administração
                                opcao = 7;

                                break;
                        }
                    }

                }
                //Apresentando o sistema de vendas
                else
                {

                }

                Console.WriteLine();
                Console.WriteLine("---Sistema encerrado---");
                Console.WriteLine();
            }
            //Capturando a exceção e mostrando na tela
            catch (ExcecaoDoSistema e)
            {
                Console.WriteLine($"Erro: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro não esperado: {e.Message}");
            }

        }
    }
}
