using ApiMySqlDocker.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiMySqlDocker.Testes
{
    [TestClass]
    public class ClienteInserirCommandTests
    {
        [DataTestMethod]
        [DataRow("Nome", "12345678901")]
        public void DadoUmComandoValidoRetorna(string nome, string cpf)
        {
            var command = new ClienteInserirCommand(nome, cpf);

            command.Validate();

            Assert.AreEqual(true, command.isValida);
            Assert.AreEqual(0, command.Notificacoes.Count);

        }

    }
}
