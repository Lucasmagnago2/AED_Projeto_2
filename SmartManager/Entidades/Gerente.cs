using System;
using SmartManager.Entidades.enums;

namespace SmartManager.Entidades
{
    internal class Gerente : Funcionario
    {

        public Gerente(string nome, int idade, long cpf, string senha, Departamento departamento) : base(nome, idade, cpf, senha, departamento)
        {
            Departamento = departamento;
        }

       public void CadastrarFuncionario()
        {

        }

        public override string ToString()
        {
            return $"Informações do Gerente\nNome: {Nome}\nIdade: {Idade}\nCpf:{Cpf}\nDepartamento: {Departamento}";
        }
    }
}
