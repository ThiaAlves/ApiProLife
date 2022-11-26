using ApiMySqlDocker.Domain.Interfaces;
using ApiMySqlDocker.Domain.Validations;

namespace ApiMySqlDocker.Domain.Commands
{
    public class UsuarioInserirCommand : Notificavel, ICommand
    {
        public UsuarioInserirCommand(string nome, string tipo_usuario, string email)
        {
            Nome = nome;
            Email = email;
            TipoUsuario = tipo_usuario;
        }

        public string Nome { get; set; }
        public string TipoUsuario { get; set; }
        public string Email { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Nome))
                AdicionarNotificacao("Nome é obrigatório");

            if (string.IsNullOrEmpty(TipoUsuario))
                AdicionarNotificacao("Tipo Usuario é obrigatório");

            if (string.IsNullOrEmpty(Email))
                AdicionarNotificacao("Email é obrigatório");
        }
    }
}
