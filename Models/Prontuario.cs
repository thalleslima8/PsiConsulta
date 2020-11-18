 using System;

namespace PsiConsulta.Models
{
    public class Prontuario
    {
        public Prontuario()
        {
        }

        public int Id { get; set; }
        public string HipoteseDiagnostico { get; set; }
        public string EvolucaoClinica { get; set; }
        public string HistoricoClinico { get; set; }
        public Paciente Paciente { get; set; }
        public Psicologo Psicologo { get; set; }

        public Prontuario(Paciente paciente, Psicologo psicologo)
        {
            HipoteseDiagnostico = "";
            EvolucaoClinica = "";
            HistoricoClinico = "";
            Paciente = paciente;
            Psicologo = psicologo;
        }

        public Paciente GetPaciente()
        {
            return Paciente;
        }

        public void AdicionaEvolucaoClinica(string mensagem)
        {
            DateTime data = DateTime.Now;

            EvolucaoClinica += $"\n{data}\n{mensagem}";
        }

        public override string ToString()
        {
            return $"Paciente: {Paciente.Nome}, Psicólogo: {Psicologo.Nome}" +
                $" Histórico Clinico: {HistoricoClinico}, \nHipotese Diagnostico: " +
                $"{HipoteseDiagnostico} \nEvolução Clínica: {EvolucaoClinica}";
        }
    }
}