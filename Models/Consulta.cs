using PsiConsulta.Models.Enums;
using System;

namespace PsiConsulta.Models
{
    public class Consulta
    {
        public Consulta()
        {
            Status = StatusConsulta.Agendada;
        }

        public int Id { get; set; }
        public DateTime Horario { get; set; }
        public Paciente Paciente { get; set; }
        public Psicologo Psicologo { get; set; }
        public decimal Taxa { get; set; }
        public StatusConsulta Status { get; set; }

        public Consulta(DateTime horario, Psicologo psicologo, Paciente paciente, decimal taxa)
        {
            Psicologo = psicologo;
            Paciente = paciente;
            Horario = horario;
            Taxa = taxa;
            Status = StatusConsulta.Agendada;
        }
    }
}