namespace ApiMySqlDocker.Entities
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especialidade {get; set;}
        public string Foto {get; set; }
        public bool Status {get; set; } 
        public int ClinicaId {get; set; }
        public Clinica Clinica {get; set;}

    }
}
