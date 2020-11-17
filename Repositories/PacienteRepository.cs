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

        public void SavePaciente(Paciente paciente)
        {
            if (!DbSet.Where(p => p.CPF == paciente.CPF).Any())
            {
                DbSet.Add(paciente);
                _context.SaveChanges();
            }


        }

        public List<Paciente> GetPacientes()
        {
            return _context.Paciente.ToList();
        }

        public Paciente GetPacientePorId(int? id)
        {
            return DbSet.Where(p => p.Id == id)
                .Include(p => p.Endereco)
                .Include(p => p.Psicologo)
                .FirstOrDefault();
        }

        public void UpdatePaciente(Paciente paciente)
        {
            
            if(!DbSet.Where(p => p.Id == paciente.Id).Any())
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
    }
}
