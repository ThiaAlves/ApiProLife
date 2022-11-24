using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApiMySqlDocker.Domain.Commands;

namespace ApiMySqlDocker.Command.ClientCommand
{
    [TestClass]
    public class ClienteInserirCommandTests
    {
        [DataTestMethod]
        [DataRow("Teste")]
        public void DadoUmComandoValidoRetorna(string nome)
        {
            var command = new ClienteInserirCommand(nome);

            command.Validate();

            Assert.AreEqual(true, command.Valido);
            Assert.AreEqual(0, command.Notificacoes.Count);
        }
        
    }
}
