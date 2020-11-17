using PsiConsulta.Models.Enums;
using PsiConsulta.Repositories;
using System.Collections.Generic;

namespace PsiConsulta.Models.ViewModels
{
    public class PacienteFormViewModel
    {
        public Paciente Paciente { get; set; }
        public ICollection<Paciente> Pacientes;
        public ICollection<StatusPaciente> Status { get; set; }
        public ICollection<Psicologo> Psicologos { get; set; }

        public PacienteFormViewModel(IPacienteRepository pacienteRepository)
        {
        }

        

    }
}
