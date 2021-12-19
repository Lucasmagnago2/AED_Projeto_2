using System;
using SmartManager.Entidades.enums;

namespace SmartManager.Entidades
{
    internal class Vendedor : Funcionario
    {

        public Vendedor(string nome, int idade, long cpf, string senha, Departamento departamento) : base(nome, idade, cpf, senha, departamento)
        {
            
        }

        public void Vender(Produto p, int qtd)
        {
            p.AlterarQuantidade(qtd * -1);
        }

        public override string ToString()
        {
            return $"Nome: {Nome}\nIdade: {Idade}\nCpf:{Cpf}\nDepartamento: {Departamento}";
        }
    }
}
