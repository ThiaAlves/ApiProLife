namespace ApiMySqlDocker.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo_Usuario { get; set; }
        //Senha com criptografia
        public string Senha { get; set; }
        public bool Status { get; set; }
       

    }
}