using ApiMySqlDocker.Domain.Interfaces;
using ApiMySqlDocker.Domain.Validations;

namespace ApiMySqlDocker.Domain.Commands
{
    public class ClienteInserirCommand : Notificavel, ICommand
    {
        public ClienteInserirCommand(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }

        public string Nome { get; set; }
        public string Cpf { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Nome))
                AdicionarNotificacao("Nome é obrigatório");

            if (string.IsNullOrEmpty(Cpf))
                AdicionarNotificacao("Cpf é obrigatório");
        }
    }
}
