using PsiConsulta.Context;
using PsiConsulta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsiConsulta.Repositories
{
    public interface IPsicologoRepository
    {
        public List<Psicologo> GetPsicologos();
    }

    public class PsicologoRepository : BaseRepository<Psicologo>, IPsicologoRepository
    {
        public PsicologoRepository(PsiContext context) : base(context)
        {
        }

        public List<Psicologo> GetPsicologos()
        {
            return _context.Psicologo.ToList();
        }
    }
}
