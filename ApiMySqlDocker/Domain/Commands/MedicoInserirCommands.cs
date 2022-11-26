using ApiMySqlDocker.Domain.Interfaces;
using ApiMySqlDocker.Domain.Validations;

namespace ApiMySqlDocker.Domain.Commands
{
    public class MedicoInserirCommand : Notificavel, ICommand
    {
        public MedicoInserirCommand(string nome, string especialidade)
        {
            Nome = nome;
            Especialidade = especialidade;
        }

        public string Nome { get; set; }
        public string Especialidade { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Nome))
                AdicionarNotificacao("Nome é obrigatório");

            if (string.IsNullOrEmpty(Especialidade))
                AdicionarNotificacao("Especialidade é obrigatório");
        }

    }
}
