namespace ApiMySqlDocker.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        //TODO Salva CPF com Hash
        public string Cpf { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public int Numero { get; set; }
        public string Telefone { get; set; }
        public string Tipo_Sanguineo { get; set; }
        public string Religiao { get; set; }
        public bool Status { get; set; } = true;

    }
}