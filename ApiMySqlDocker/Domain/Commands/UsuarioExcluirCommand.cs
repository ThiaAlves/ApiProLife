using ApiMySqlDocker.Domain.Interfaces;
using ApiMySqlDocker.Domain.Validations;

namespace ApiMySqlDocker.Domain.Commands
{
    public class UsuarioExcluirCommand : Notificavel, ICommand
    {
        public int Id { get; set; }

        public UsuarioExcluirCommand() { }
        
        public UsuarioExcluirCommand(int id)
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
