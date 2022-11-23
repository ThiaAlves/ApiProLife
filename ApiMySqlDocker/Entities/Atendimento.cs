using System.ComponentModel.DataAnnotations;

namespace ApiMySqlDocker.Entities
{
    public class Atendimento
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
        public int ClinicaId { get; set; }
        public Clinica Clinica { get; set; }
        public string Tipo_Atendimento { get; set; }
        public string Data_Atendimento { get; set; }
        public string Observacao { get; set; }

        public Atendimento() { }

        public Atendimento(int id, int clienteId, Cliente cliente, int medicoId, Medico medico, int clinicaId, Clinica clinica, string tipo_Atendimento, string data_Atendimento, string observacao)
        {
            Id = id;
            ClienteId = clienteId;
            Cliente = cliente;
            MedicoId = medicoId;
            Medico = medico;
            ClinicaId = clinicaId;
            Clinica = clinica;
            Tipo_Atendimento = tipo_Atendimento;
            Data_Atendimento = data_Atendimento;
            Observacao = observacao;
        }

        public Atendimento(int clienteId, Cliente cliente, int medicoId, Medico medico, int clinicaId, Clinica clinica, string tipo_Atendimento, string data_Atendimento, string observacao)
        {
            ClienteId = clienteId;
            Cliente = cliente;
            MedicoId = medicoId;
            Medico = medico;
            ClinicaId = clinicaId;
            Clinica = clinica;
            Tipo_Atendimento = tipo_Atendimento;
            Data_Atendimento = data_Atendimento;
            Observacao = observacao;
        }

        public Atendimento(int id, int clienteId, int medicoId, int clinicaId, string tipo_Atendimento, string data_Atendimento, string observacao)
        {
            Id = id;
            ClienteId = clienteId;
            MedicoId = medicoId;
            ClinicaId = clinicaId;
            Tipo_Atendimento = tipo_Atendimento;
            Data_Atendimento = data_Atendimento;
            Observacao = observacao;
        }
    }
}