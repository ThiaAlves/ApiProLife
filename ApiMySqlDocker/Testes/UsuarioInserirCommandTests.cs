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
        [DataRow("Nome", "administrador", "admin@gmail.com")]
        public void DadoUmComandoValidoRetorna(string nome, string tipo_usuario, string email)
        {
            var command = new UsuarioInserirCommand(nome, tipo_usuario, email);

            command.Validate();

            Assert.AreEqual(true, command.isValida);

        }

    }
}
