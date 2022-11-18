namespace ApiMySqlDocker.Entities
{
    public class Medico
    {

        public Medico() { }

        public Medico(string nome, string especialidade, string foto, bool status, int clinicaId)
        {
            Nome = nome;
            Especialidade = especialidade;
            Foto = foto;
            Status = status;
            ClinicaId = clinicaId;
        }

        public Medico(int id, string nome, string especialidade, string foto, bool status, int clinicaId)
        {
            Id = id;
            Nome = nome;
            ClinicaId = clinicaId;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }
        public string Foto { get; set; }
        public bool Status { get; set; }
        public int ClinicaId { get; set; }
        public Clinica Clinica { get; set; }

    }
}