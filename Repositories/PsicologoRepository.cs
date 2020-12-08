using Microsoft.EntityFrameworkCore;
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
        public Task<List<Psicologo>> GetPsicologos();
        public Task<Psicologo> GetPsicologoPorId(int? id);
        public Task SavePsicologo(Psicologo psicologo);
        public Task UpdatePsicologo(Psicologo psicologo);
        public Task RemovePsicologo(int id);
        public bool PsicologoExists(int id);
    }

    public class PsicologoRepository : BaseRepository<Psicologo>, IPsicologoRepository
    {
        public PsicologoRepository(PsiContext context) : base(context)
        {
        }

        public bool PsicologoExists(int id)
        {
            if(DbSet.Where(p => p.Id == id).FirstOrDefault() != null)
            {
                return true;
            }
            return false;
        }

        public async Task<Psicologo> GetPsicologoPorId(int? id)
        {
            return await DbSet.Where(p => p.Id == id).Include(p => p.Pacientes).ThenInclude(p => p.Consultas).FirstOrDefaultAsync();
        }

        public async Task<List<Psicologo>> GetPsicologos()
        {
            return await _context.Psicologo.ToListAsync();
        }


        public async Task RemovePsicologo(int id)
        {
            if (PsicologoExists(id))
            {
                var psicologo = await DbSet.Where(p => p.Id == id).FirstOrDefaultAsync();
                _context.Remove(psicologo);
                _context.SaveChanges();
            }
        }

        public async Task SavePsicologo(Psicologo psicologo)
        {
            var exist = await DbSet.Where(p => p.CPF == psicologo.CPF).AnyAsync();
            if (!exist)
            {
                DbSet.Add(psicologo);
                _context.SaveChanges();
            }
        }

        public async Task UpdatePsicologo(Psicologo psicologo)
        {
            var exist = await DbSet.Where(p => p.Id == psicologo.Id).AnyAsync();
            if (!exist)
            {
                throw new NullReferenceException("Paciente não encontrado!");
            }

            try
            {
                _context.Update(psicologo);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new Exception("DbUpdateConcurrencyException: " + e.Message);
            }
        }
    }
}
