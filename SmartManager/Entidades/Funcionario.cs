using System;
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
        public override string ToString()
        {
            return $"Nome: {Nome}\nIdade: {Idade}\nCpf:{Cpf}\nDepartamento: {Departamento}";
        }


    }
}
