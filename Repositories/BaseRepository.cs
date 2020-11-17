using Microsoft.EntityFrameworkCore;
using PsiConsulta.Context;
using PsiConsulta.Models;

namespace PsiConsulta.Repositories
{
    public class BaseRepository<T> where T : Pessoa
    {
        protected readonly PsiContext _context;
        protected readonly DbSet<T> DbSet;

        public BaseRepository(PsiContext context)
            {
            _context = context;
            DbSet = _context.Set<T>();
        }
    }
}