using PsiConsulta.Context;
using PsiConsulta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsiConsulta.Services
{
    public class PsicologoService
    {
        private readonly PsiContext _context;

        public PsicologoService(PsiContext context)
        {
            _context = context;
        }

        public List<Psicologo> FindAll()
        {
            return _context.Psicologo.OrderBy(p => p.Nome).ToList();
        }
    }
}
