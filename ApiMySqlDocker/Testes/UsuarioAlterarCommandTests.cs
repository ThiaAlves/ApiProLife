using ApiMySqlDocker.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiMySqlDocker.Testes
{
    [TestClass]
    public class UsuarioAlterarCommandTests
    {
        [DataRow(0, "", false, 2)]
        [DataRow(1, "", false, 1)]
        [DataRow(0, "Nome", false, 1)]
        [DataRow(1, "Nome", true, 0)]
        [DataRow(2, "Outro Nome", true, 0)]
        public void DadoUmComandoInvalidoRetornaClasseInvalida(
            int id, string nome, bool valida, int qtdErro)
        {
            var command = new UsuarioAlterarCommand(id, nome);

            command.Validate();

            Assert.AreEqual(valida, command.isValida);
            Assert.AreEqual(qtdErro, command.Notificacoes.Count);
        }
    }
}
