using System;
using System.IO;
using System.Collections.Generic;
using SmartManager.Entidades.enums;

namespace SmartManager.Entidades
{
    internal class Funcionario
    {
        public string Nome { get; private set; }
        public int Idade { get; private set; }
        public long Cpf { get; private set; }
        public long Id { get; private set; }

        public string Senha { get; private set; }
        public Departamento Departamento { get; set; }

        public Funcionario()
        {

        }
        public Funcionario(string nome, int idade, long cpf,  string senha, Departamento departamento)
        {
            Nome = nome;
            Idade = idade;
            VerificarCPF(cpf);
            AlteraSenha(senha);
            Departamento = departamento;
        }
        //Método que verifica se o CPF é valido
        public void VerificarCPF(long cpf)
        {
            if(cpf.ToString().Length < 11 || cpf.ToString().Length > 11)
            {
                throw new ExcecaoDoSistema("O CPF fornecido não é válido");
            }
            else
            {
                Cpf = cpf;
            }
        }
        //Verificando se a senha tem o tamanho mínimo
        public void AlteraSenha(string senha)
        {
            if(senha.Length < 5)
            {
                throw new ExcecaoDoSistema("A senha deve conter pelo menos 5 caracteres");
            }
            else
            {
                Senha = senha;
            }
        }
        public static void AtualizarBaseDeFuncionarios(List<Funcionario> lista)
        {
            FileStream baseFuncionarios = new FileStream("C:\\Users\\Lucas\\desktop\\SmartManager\\SmartManager\\Arquivos\\funcionarios.txt", FileMode.Open, FileAccess.Write);
            StreamWriter swFuncionarios = new StreamWriter(baseFuncionarios);

            foreach (Funcionario f in lista)
            {
                string dadosFuncionario = $"{f.Nome};{f.Idade};{f.Cpf};{f.Senha};{f.Departamento}";

                swFuncionarios.WriteLine(dadosFuncionario);
            }

            swFuncionarios.Close();
            baseFuncionarios.Close();
        }

        //Atualizando a lista de funcionários com os dados da base de dados.
        public static void AtualizarListaDeFuncionarios(List<Funcionario> lista)
        {
            string[] funcionarios = File.ReadAllLines("C:\\Users\\Lucas\\desktop\\SmartManager\\SmartManager\\Arquivos\\funcionarios.txt");

            foreach (string func in funcionarios)
            {
                string[] dadosFuncionario = func.Split(";");

                string nome = dadosFuncionario[0];
                int idade = int.Parse(dadosFuncionario[1]);
                long cpf = long.Parse(dadosFuncionario[2]);
                string senha = dadosFuncionario[3];
                Departamento departamento = Enum.Parse<Departamento>(dadosFuncionario[4]);

                if (departamento == Departamento.Administração)
                {
                    lista.Add(new Gerente(nome, idade, cpf, senha, departamento));
                }
                else
                {
                    lista.Add(new Vendedor(nome, idade, cpf, senha, departamento));
                }
            }
        }
        public override string ToString()
        {
            return $"Nome: {Nome}\nIdade: {Idade}\nCpf: {Cpf}\nDepartamento: {Departamento}";
        }


    }
}
