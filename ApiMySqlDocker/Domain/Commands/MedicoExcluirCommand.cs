using ApiMySqlDocker.Domain.Interfaces;
using ApiMySqlDocker.Domain.Validations;


namespace ApiMySqlDocker.Domain.Commands
{
    public class MedicoExcluirCommand : Notificavel, ICommand
    {
        public int Id { get; set; }

        public MedicoExcluirCommand() { }

        public MedicoExcluirCommand(int id)
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
