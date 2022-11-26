using ApiMySqlDocker.Domain.Interfaces;
using ApiMySqlDocker.Domain.Validations;

namespace ApiMySqlDocker.Domain.Commands
{
    public class ClienteExcluirCommand : Notificavel, ICommand
    {
        public int Id { get; set; }

        public ClienteExcluirCommand() { }

        public ClienteExcluirCommand(int id)
        {
            Id = id;
        }

        public void Validate()
        {
            if (Id <= 0)
                AdicionarNotificacao("Código informado inválido");
        }
    }
}
