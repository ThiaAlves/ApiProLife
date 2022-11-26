using ApiMySqlDocker.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiMySqlDocker.Testes
{
    [TestClass]
    public class UsuarioExcluirCommandTests
    {
        [DataTestMethod]
        [DataRow(0, false)]
        [DataRow(1, true)]
        [DataRow(-2, false)] 
        public void DadoUmComandoDeveValidarCorretamente(int id, bool valida)
        {
            var command = new UsuarioExcluirCommand(id);
            command.Validate();

            Assert.AreEqual(valida, command.isValida);
        }
    }
}

