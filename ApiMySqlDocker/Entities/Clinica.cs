namespace ApiMySqlDocker.Entities
{
    public class Clinica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public int Numero {get; set; }
        public string Latitude {get; set; }
        public string Longitude {get; set; }
        public bool Status {get; set; } = true;

    }
}
