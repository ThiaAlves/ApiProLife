using ApiMySqlDocker.Config;
using System.Collections.Generic;
using System.Linq;
using ApiMySqlDocker.Entities;

namespace ApiMySqlDocker.Repositories
{
    public static class UsuarioRepository
    {
        public static Usuario Get(string email, string senha)
        {
            var users = new List<Usuario>();
            users.Add(new Usuario
            {
                Nome = "admin",
                Tipo_Usuario = "Administrador",
                Email = "admin@gmail.com",
                Senha = Criptografia.MD5Encrypt("123456"),
                Status = true
            });
            return users.Where(x => x.Email == email).FirstOrDefault();
        }
    }
}