using ApiMySqlDocker.Config;
using ApiMySqlDocker.Domain.Commands;
using ApiMySqlDocker.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiMySqlDocker.Testes
{
    [TestClass]
    public class ClienteExcluirCommandTests
    {
        [DataTestMethod]
        [DataRow(0, false)]
        [DataRow(1, true)]
        [DataRow(2, true)]
        public void DadoUmComandoDeveValidarCorretamente(int id, bool valida)
        {
            var command = new ClienteExcluirCommand(id);
            command.Validate();

            Assert.AreEqual(valida, command.isValida);
        }
    }
}
