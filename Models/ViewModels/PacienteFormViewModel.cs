using PsiConsulta.Models.Enums;
using System.Collections.Generic;

namespace PsiConsulta.Models.ViewModels
{
    public class PacienteFormViewModel
    {
        public Paciente Paciente { get; set; }
        public ICollection<StatusPaciente> Status { get; set; }
        public List<string> Estados { get; set; }

        public PacienteFormViewModel()
        {
        }

    }
}
