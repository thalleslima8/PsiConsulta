using PsiConsulta.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PsiConsulta.Repositories
{
    public interface IPacienteRepository
    {
        public Task SavePaciente(Paciente paciente);
        public Task<List<Paciente>> GetPacientes();
        public Task<Paciente> GetPacientePorId(int? id);
        public Task UpdatePaciente(Paciente paciente);
        public Task RemovePaciente(int id);
        public Task<bool> PacienteExists(int id);
    }
}