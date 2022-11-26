using ApiMySqlDocker.Domain.Interfaces;
using ApiMySqlDocker.Domain.Validations;
using System.Diagnostics.CodeAnalysis;

namespace ApiMySqlDocker.Domain.Commands

{    public class MedicoAlterarCommand : Notificavel, ICommand
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [ExcludeFromCodeCoverage]
        public MedicoAlterarCommand() { }

        public MedicoAlterarCommand(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void Validate()
        {
            if (Id <= 0)
                AdicionarNotificacao("Código informado inválido");

            if (string.IsNullOrEmpty(Nome))
                AdicionarNotificacao("O nome deve ser informado");
        }

    }
}
