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
        public string Tipo_Atendimento { get; set; }
        public string Data_Atendimento { get; set; }
        public string Observacao { get; set; }

        public Atendimento() { }

        public Atendimento(int clienteId, int medicoId, string tipo_Atendimento, string data_Atendimento, string observacao)
        {
            ClienteId = clienteId;
            MedicoId = medicoId;
            Tipo_Atendimento = tipo_Atendimento;
            Data_Atendimento = data_Atendimento;
            Observacao = observacao;
        }

        public Atendimento(int id, int clienteId, int medicoId, string tipo_Atendimento, string data_Atendimento, string observacao)
        {
            Id = id;
            ClienteId = clienteId;
            MedicoId = medicoId;
            Tipo_Atendimento = tipo_Atendimento;
            Data_Atendimento = data_Atendimento;
            Observacao = observacao;
        }

        public Atendimento(int id, int clienteId, int medicoId, string tipo_Atendimento, string data_Atendimento, string observacao, Cliente cliente, Medico medico)
        {
            Id = id;
            ClienteId = clienteId;
            MedicoId = medicoId;
            Tipo_Atendimento = tipo_Atendimento;
            Data_Atendimento = data_Atendimento;
            Observacao = observacao;
            Cliente = cliente;
            Medico = medico;
        }
    }
}