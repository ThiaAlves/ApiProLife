using ApiMySqlDocker.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiMySqlDocker.Testes
{
    [TestClass]
    public class ClienteInserirCommandTests
    {
        [DataTestMethod]
        [DataRow("Nome")]
        [DataRow("Outro Nome")]
        public void DadoUmComandoValidoRetorna(string nome)
        {
            var command = new ClienteInserirCommand(nome);

            command.Validate();

            Assert.AreEqual(true, command.isValida);
            Assert.AreEqual(0, command.Notificacoes.Count);

        }

    }
}
