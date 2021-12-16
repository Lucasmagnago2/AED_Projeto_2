using System;
using SmartManager.Entidades.enums;
using System.Collections.Generic;
using System.Text;

namespace SmartManager.Entidades
{
    internal class Gerente : Funcionario
    {
        public Departamento Departamento { get; set; }

        public Gerente(string nome, int idade, long cpf, string senha, Departamento departamento) : base(nome, idade, cpf, senha)
        {
            Departamento = departamento;
        }

       public void CadastrarFuncionario()
        {

        }
    }
}
