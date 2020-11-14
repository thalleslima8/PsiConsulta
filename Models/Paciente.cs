using System;
using System.Collections.Generic;
using PsiConsulta.Models.Enums;

namespace PsiConsulta.Models
{
    public class Paciente : Pessoa
    {
        public Paciente() { }

        public List<Consulta> Consultas { get; set; }
        public string Profissao { get; set; } = "";
        public Endereco Endereco { get; set; }
        public Psicologo Psicologo { get; set; }
        public StatusPaciente Status { get; set; }
        public Prontuario Prontuario { get; set; }

        public Paciente(string prof, Endereco endereco, Psicologo psi)
        {
            Profissao = prof;
            Endereco = endereco;
            Psicologo = psi;
            Status = StatusPaciente.Ativo;
            
        }

        public void DesativaPaciente()
        {
            Status = StatusPaciente.Finalizado;
        }

        public Psicologo GetPsicologo()
        {
            return Psicologo;
        }

        public Prontuario GetProntuario()
        {
            if (Prontuario == null) throw new ArgumentException("Não Existe Prontuário"); 
            return Prontuario;
        }

        public void NovoProntuario(Prontuario prontuario)
        {
            Prontuario = prontuario;
        }

    }
}