using PsiConsulta.Models;
using System.Collections.Generic;

namespace PsiConsulta.Repositories
{
    public interface IPacienteRepository
    {
        void SavePaciente(Paciente paciente);
        public List<Paciente> GetPacientes();
        public Paciente GetPacientePorId(int? id);
        public void UpdatePaciente(Paciente paciente);
    }
}