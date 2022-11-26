using ApiMySqlDocker.Config;
using ApiMySqlDocker.Domain.Commands;
using ApiMySqlDocker.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiMySqlDocker.Testes
{
    [TestClass]
    public class MedicoInserirCommandTests
    {
        [DataTestMethod]
        [DataRow("Nome")]
        [DataRow("Outro Nome")]
        public void DadoUmComandoValidoRetorna(string nome)
        {
            var command = new MedicoInserirCommand(nome);

            command.Validate();

            Assert.AreEqual(true, command.isValida);
            Assert.AreEqual(0, command.Notificacoes.Count);

        }

    }
}
