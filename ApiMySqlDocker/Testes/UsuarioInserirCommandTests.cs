using ApiMySqlDocker.Config;
using ApiMySqlDocker.Domain.Commands;
using ApiMySqlDocker.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiMySqlDocker.Testes
{
    [TestClass]
    public class UsuarioInserirCommandTests
    {
        [DataTestMethod]
        [DataRow("Nome")]
        [DataRow("Outro Nome")]
        public void DadoUmComandoValidoRetorna(string nome)
        {
            var command = new UsuarioInserirCommand(nome);

            command.Validate();

            Assert.AreEqual(true, command.isValida);

        }

    }
}
