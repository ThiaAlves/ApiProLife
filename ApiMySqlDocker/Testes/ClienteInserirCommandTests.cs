using ApiMySqlDocker.Config;
using ApiMySqlDocker.Domain.Commands;
using ApiMySqlDocker.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiMySqlDocker.Testes
{
    [TestClass]
    public class ClienteInserirCommandTests
    {
        [DataTestMethod]
        [DataRow("Nome")]
        public void DadoUmComandoValidoRetorna(string nome)
        {
            var command = new ClienteInserirCommand(nome);

            command.Validate();

            Assert.AreEqual(true, command.Valido);
            Assert.AreEqual(0, command.Notificacoes.Count);

        }

    }
}
