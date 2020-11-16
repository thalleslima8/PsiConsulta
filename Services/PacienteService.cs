using PsiConsulta.Context;
using PsiConsulta.Models;
using System.Collections.Generic;
using System.Linq;

namespace PsiConsulta.Services
{
    public class PacienteService
    {
        private readonly PsiContext _context;

        public PacienteService(PsiContext context)
        {
            _context = context;
        }

        public List<Paciente> FindAll()
        {
            return _context.Paciente.OrderBy(p => p.Nome).ToList();
        }
    }
}
