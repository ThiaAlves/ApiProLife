using ApiMySqlDocker.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiMySqlDocker.Testes
{
    [TestClass]
    public class MedicoExcluirCommandTests
    {
        [DataTestMethod]
        [DataRow(0, false)]
        [DataRow(1, true)]
        [DataRow(-1, false)]
        [DataRow(2, true)]
        public void DadoUmComandoDeveValidarCorretamente(int id, bool valida)
        {
            var command = new MedicoExcluirCommand(id);
            command.Validate();

            Assert.AreEqual(valida, command.isValida);
        }
    }
}
