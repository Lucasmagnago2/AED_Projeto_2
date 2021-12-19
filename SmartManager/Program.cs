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
        public static Funcionario Login(List<Funcionario> lista)
        {
            //Estado do login
            string situacaoLogin = EstadoLogin.Deslogado.ToString();

            //Funcionario Ativo
            Funcionario funcionarioAtivo = new Funcionario(); 

            //Solicitando e verificando login e senha do funcionario, o loop continuará enquanto não for
            //inserido um login e senha corretos
            while (situacaoLogin != EstadoLogin.Logado.ToString())
            {
                Console.Clear();

                //Solicitando login e senha
                Console.WriteLine("------SmartManager------");
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

                        //Armazenando o funcionário que efetuou o login
                        funcionarioAtivo = funcionario;

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
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                }

            }

            //Retornando o funcionario que efetuou o login
            return funcionarioAtivo;
        }

        //Menu Administração
        public static int MenuAdministracao()
        {
            Console.WriteLine();
            Console.WriteLine("1. Cadastrar produto");
            Console.WriteLine("2. Editar produto");
            Console.WriteLine("3. Relatório do estoque");
            Console.WriteLine("4. Relatório de vendas");
            Console.WriteLine("5. Relatório de funcionários");
            Console.WriteLine("6. Cadastrar funcionário");
            Console.WriteLine("7. Remover funcionário");
            Console.WriteLine("8. Redefinir senha");
            Console.WriteLine("0. Sair");
            Console.WriteLine();

            Console.Write("Selecione um opção: ");

            int opcao = int.Parse(Console.ReadLine());

            //Verificar se a opção escolhida é válida
            if (opcao < 0 || opcao > 8)
            {
                //Lançar erro caso opção escolhida seja inválida
                throw new ExcecaoDoSistema("A opção escolhida não é válida.");
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

                //Criando o setor de administração
                Administracao administracao = new Administracao();

                //Atualizando as listas de Funcionários, Produtos e vendas com os dados das base de dados
                Funcionario.AtualizarListaDeFuncionarios(funcionarios);
                Produto.AtualizarListaDeProdutos(administracao.Estoque);
                Venda.AtualizarListaDeVendas(administracao.Vendas);

                //Iniciando o sistema
                //Chamando a função login
                Funcionario funcionarioAtivo = Login(funcionarios);

                Console.WriteLine();

                //Apresentando o sistema de administração
                if (funcionarioAtivo.Departamento == Departamento.Administração)
                {

                    //Realizando o downcasting do funcionario ativo (que nesse caso é um gerente)
                    //para utilizar os métodos da classe Gerente
                    Gerente gerenteAtivo = (Gerente)funcionarioAtivo;

                    int opcao = -1;

                    while (opcao != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("---Administração---");

                        //Chamar menu de administração e pegar opção escolhida do usuário
                        opcao = MenuAdministracao();

                        switch (opcao)
                        {
                            case 1:
                                //1. Cadastrar produto
                                Console.Clear();
                                Console.WriteLine("---Cadastrar produto---");
                                Console.WriteLine();

                                Console.Write("Quantos produtos você quer cadastrar? ");
                                int qtd = int.Parse(Console.ReadLine());

                                for (int i = 0; i < qtd; i++)
                                {
                                    //Solicitando os dados desse novo produto
                                    Console.WriteLine();
                                    Console.WriteLine($"Cadastro nº {i + 1}");
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
                                    gerenteAtivo.CadastrarProduto(administracao.Estoque, id, nome, valorCusto, margemLucro, quantidade);
                                }
                                Console.WriteLine();
                                Console.WriteLine("Cadastro de produtos finalizado!");
                                Console.WriteLine();
                                Console.WriteLine("Pressione qualquer tecla para continuar...");
                                Console.ReadLine();
                                break;

                            case 2:
                                //2. Editar produto
                                Console.Clear();
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

                                        //Alterando valor de custo
                                        produtoEditar.AlterarValorCusto(valorCustoProduto);

                                        Console.WriteLine();
                                        Console.WriteLine("Valor de custo alterado com sucesso");
                                        Console.WriteLine();
                                        break;

                                    case 3:
                                        //3. Margem de lucro
                                        Console.WriteLine();
                                        Console.Write("Digite a margem de lucro (%): ");
                                        double margemLucroProduto = double.Parse(Console.ReadLine());

                                        //Alterando margem de lucro
                                        produtoEditar.AlterarMargemLucro(margemLucroProduto);

                                        Console.WriteLine();
                                        Console.WriteLine("Margem de lucro alterada com sucesso");
                                        Console.WriteLine();
                                        break;
                                }

                                Console.WriteLine("---Fim de edição de produto---");
                                Console.WriteLine();
                                Console.WriteLine("Pressione qualquer tecla para continuar...");
                                Console.ReadLine();
                                break;

                            case 3:
                                //3. Relatório do estoque
                                Console.Clear();
                                Console.WriteLine("---Relatório do Estoque---");

                                administracao.RelatorioEstoque();

                                Console.WriteLine();
                                Console.WriteLine("---Fim do relatório---");
                                Console.WriteLine();
                                Console.WriteLine("Pressione qualquer tecla para continuar...");
                                Console.ReadLine();
                                break;

                            case 4:
                                //4. Relatório de vendas
                                Console.Clear();
                                Console.WriteLine("---Relatório de vendas---");

                                administracao.RelatorioVendas();

                                Console.WriteLine();
                                Console.WriteLine("---Fim de vendas---");
                                Console.WriteLine();
                                Console.WriteLine("Pressione qualquer tecla para continuar...");
                                Console.ReadLine();
                                break;

                            case 5:
                                //5. Relatório de funcionários
                                Console.Clear();
                                Console.WriteLine("---Relatório do Funcionários---");
                                Console.WriteLine();

                                int iii = 0;

                                foreach (Funcionario f in funcionarios)
                                {
                                    Console.WriteLine($"Funcionário {iii + 1}");
                                    Console.WriteLine(f);
                                    Console.WriteLine();

                                    iii++;
                                }
                                
                                Console.WriteLine();
                                Console.WriteLine("---Fim do relatório---");
                                Console.WriteLine();
                                Console.WriteLine("Pressione qualquer tecla para continuar...");
                                Console.ReadLine();
                                break;


                            case 6:
                                //6. Cadastrar funcionário
                                Console.Clear();
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

                                    //Chamando o método da classe Gerente para realizar o cadastro e adicionar o funcionário na lista
                                    gerenteAtivo.CadastrarFuncionario(funcionarios, nomeCadastro, idadeCadastro, cpfCadastro, senhaInicial, departamentoCadastro);

                                }

                                Console.WriteLine();
                                Console.WriteLine("---Fim do cadastro de funcionários---");
                                Console.WriteLine();
                                Console.WriteLine("Pressione qualquer tecla para continuar...");
                                Console.ReadLine();
                                break;



                            case 7:
                                //7. Remover funcionário
                                Console.Clear();
                                Console.WriteLine("---Remover funcionário---");

                                Console.Write("Digite o CPF do funcionario a ser removido: ");
                                long cpfRemover = long.Parse(Console.ReadLine());

                                gerenteAtivo.RemoverFuncionario(funcionarios, cpfRemover);

                                Console.WriteLine("---Fim da remoção de funcionário---");
                                Console.WriteLine();
                                Console.WriteLine("Pressione qualquer tecla para continuar...");
                                Console.ReadLine();
                                break;

                            case 8:
                                //8. Alterar senha
                                Console.Clear();
                                Console.WriteLine("---Alterar senha---");
                                Console.WriteLine();

                                Console.Write("Digite uma nova senha (a senha tem que ter ao menos 5 digitos): ");
                                string novaSenha = Console.ReadLine();

                                //Alterando a senha do funcionário
                                funcionarioAtivo.AlteraSenha(novaSenha);

                                Console.WriteLine();
                                Console.WriteLine("Senha alterada com sucesso");
                                Console.WriteLine();
                                Console.WriteLine("---Fim de alterar senha---");
                                break;

                            case 0:
                                //0. Sair
                                Console.Clear();

                                //Atualizar base de dados de funcionários
                                Funcionario.AtualizarBaseDeFuncionarios(funcionarios);

                                //Atualizar base de dados de produtos
                                Produto.AtualizarBaseDeProdutos(administracao.Estoque);

                                //Atualizar base de dados de vendas
                                Venda.AtualizarBaseDeVendas(administracao.Vendas);

                                //Encerrando o loop do sistema da Administração
                                opcao = 0;

                                break;
                        }
                    }

                }
                //Apresentando o sistema de vendas
                else
                {
                    //Realizando o downcasting do funcionario ativo (que nesse caso é um vendedor)
                    //para utilizar os métodos da classe Vendedor
                    Vendedor vendedorAtivo = (Vendedor)funcionarioAtivo;

                    int opcao = -1;

                    while(opcao != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("---Vendas---");
                        Console.WriteLine();
                        Console.WriteLine("1. Realizar venda");
                        Console.WriteLine("0. Sair");
                        Console.WriteLine();
                        Console.Write("> ");

                        foreach(Venda v in administracao.Vendas)
                        {
                            Console.WriteLine();
                            Console.WriteLine(v);
                            Console.WriteLine();
                        }

                        opcao = int.Parse(Console.ReadLine());

                        switch (opcao)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("---Realizar venda---");
                                Console.WriteLine();
                                Console.WriteLine("Para encerrar a venda digite 0");
                                int id = -1;
                                double total = 0;

                                while(id != 0)
                                {
                                    Console.WriteLine();
                                    Console.Write("Id do produto: ");
                                    id = int.Parse(Console.ReadLine());

                                    //Verificando se o id inserido corresponde a algum produto da lista
                                    Produto p = administracao.Estoque.Find(x => x.Id == id);

                                    if(p != null)
                                    {
                                        Console.Write("Quantidade: ");
                                        int qtd = int.Parse(Console.ReadLine());

                                        if(qtd < 0)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("A quantidade de produtos não pode ser negativa");
                                            Console.WriteLine();
                                        }
                                        else
                                        {
                                            vendedorAtivo.Vender(p, qtd);

                                            total = Venda.CalcularTotal(p, qtd, total);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Produto não encontrado");
                                        Console.WriteLine();
                                    }
                                }

                                DateTime dataVenda = DateTime.Now;
                                string vendedorVenda = vendedorAtivo.Nome;

                                Venda vendaAtual = new Venda(vendedorVenda, dataVenda, total);
                                administracao.Vendas.Add(vendaAtual);

                                Console.Clear();
                                Console.WriteLine("---Venda Realizada---");
                                Console.WriteLine();
                                Console.WriteLine("Informações da venda: ");
                                Console.WriteLine();
                                Console.WriteLine(vendaAtual);
                                Console.WriteLine();
                                Console.WriteLine("---Fim da venda---");
                                Console.WriteLine();
                                Console.WriteLine("Pressione qualquer tecla para continuar...");
                                Console.ReadLine();
                                break;

                            case 0:
                                //0. Sair

                                //Atualizar base de dados de funcionários
                                Funcionario.AtualizarBaseDeFuncionarios(funcionarios);

                                //Atualizar base de dados de produtos
                                Produto.AtualizarBaseDeProdutos(administracao.Estoque);

                                //Atualizar base de dados de vendas
                                Venda.AtualizarBaseDeVendas(administracao.Vendas);

                                //Encerrar loop do sistema
                                opcao = 0;
                                break;

                            default:
                                Console.WriteLine("Opção inválida");
                                break;
                                
                        }
                    }
                }

                Console.Clear();
                Console.WriteLine("---Sistema encerrado---");
            }
            //Capturando a exceção e mostrando na tela
            catch (ExcecaoDoSistema e)
            {
                Console.Clear();
                Console.WriteLine($"Erro: {e.Message}");
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine($"Erro não esperado: {e.Message}");
            }

        }
    }
}
