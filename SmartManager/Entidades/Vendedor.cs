using System;
using SmartManager.Entidades.enums;
using System.Collections.Generic;
using System.Text;

namespace SmartManager.Entidades
{
    internal class Vendedor : Funcionario
    {
        public Departamento Departamento { get; set; }

        public Vendedor(string nome, int idade, long cpf, string senha, Departamento departamento) : base(nome, idade, cpf, senha)
        {
            Departamento = departamento;
        }

        public void Vender()
        {

        }
    }
}
