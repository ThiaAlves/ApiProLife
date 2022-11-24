using System.Collections.Generic;

namespace ApiMySqlDocker.Domain.Validations
{
    public abstract class Notificavel
    {
        private readonly List<string> _notificacoes;

        protected Notificavel()
        {
            _notificacoes = new List<string>();
        }

        public void AdicionarNotificacao(string mensagem)
        {
            _notificacoes.Add(mensagem);
        }

        public IReadOnlyCollection<string> Notificacoes => _notificacoes;

        public bool Valido => _notificacoes.Count == 0;
        
    }
}
