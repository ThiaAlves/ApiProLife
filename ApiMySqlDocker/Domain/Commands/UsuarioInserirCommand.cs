using ApiMySqlDocker.Domain.Interfaces;
using ApiMySqlDocker.Domain.Validations;

namespace ApiMySqlDocker.Domain.Commands
{
    public class UsuarioInserirCommand : Notificavel, ICommand
    {
        public UsuarioInserirCommand(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Nome))
                AdicionarNotificacao("Nome é obrigatório");
        }
    }
}
