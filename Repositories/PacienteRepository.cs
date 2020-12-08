using Microsoft.EntityFrameworkCore;
using PsiConsulta.Context;
using PsiConsulta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsiConsulta.Repositories
{
    public class PacienteRepository : BaseRepository<Paciente>, IPacienteRepository
    {
        public PacienteRepository(PsiContext context) : base(context)
        {
        }

        public async Task SavePaciente(Paciente paciente)
        {
            var exist = await DbSet.Where(p => p.CPF == paciente.CPF).AnyAsync();
            if (!exist)
            {
                DbSet.Add(paciente);
                _context.SaveChanges();
            }
        }

        public async Task<List<Paciente>> GetPacientes()
        {
            return await _context.Paciente.ToListAsync();
        }

        public async Task<Paciente> GetPacientePorId(int? id)
        {
            return await DbSet.Where(p => p.Id == id)
                .Include(p => p.Endereco)
                .Include(p => p.Psicologo)
                .FirstOrDefaultAsync();
        }

        public async Task UpdatePaciente(Paciente paciente)
        {
            var exist = await DbSet.Where(p => p.Id == paciente.Id).AnyAsync();
            if(!exist)
            {
                throw new NullReferenceException("Paciente não encontrado!");
            }

            try
            {
                _context.Update(paciente);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new Exception("DbUpdateConcurrencyException: " + e.Message);
            }
        }

        public async Task RemovePaciente(int id)
        {
            if (await PacienteExists(id))
            {
                var paciente = await DbSet.Where(p => p.Id == id).FirstOrDefaultAsync();
                _context.Remove(paciente);
                _context.SaveChanges();
            }

        }

        public async Task<bool> PacienteExists(int id)
        {
            if (await DbSet.Where(p => p.Id == id).FirstOrDefaultAsync() != null)
            {
                return true;
            }
            return false;
        }
    }
}
