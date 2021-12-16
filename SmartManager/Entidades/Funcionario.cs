namespace SmartManager.Entidades
{
    internal class Funcionario
    {
        public string Nome { get; private set; }
        public int Idade { get; private set; }
        public long Cpf { get; private set; }
        public long Id { get; private set; }

        public string Senha { get; private set; }

        public Funcionario()
        {

        }
        public Funcionario(string nome, int idade, long cpf,  string senha)
        {
            Nome = nome;
            Idade = idade;
            Cpf = cpf;
            Login();
            AlteraSenha(senha);
        }
        public void Login()
        {
            Id = Cpf;
        }
        public void AlteraSenha(string senha)
        {
            if(senha.Length > 5)
            {
                Senha = senha;
            }
        }
    }
}
