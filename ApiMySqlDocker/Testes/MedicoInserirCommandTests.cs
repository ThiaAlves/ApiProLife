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
        [DataRow("Nome", "Pediatria")]
        public void DadoUmComandoValidoRetorna(string nome, string especialidade)
        {
            var command = new MedicoInserirCommand(nome, especialidade);

            command.Validate();

            Assert.AreEqual(true, command.isValida);
            Assert.AreEqual(0, command.Notificacoes.Count);

        }

    }
}
