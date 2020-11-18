using Microsoft.EntityFrameworkCore;
using PsiConsulta.Models;
using PsiConsulta.Models.Enums;
using PsiConsulta.Models.Financiero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsiConsulta.Context
{
    public class PsiContext : DbContext
    {
        public PsiContext(DbContextOptions<PsiContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Endereco>().HasKey(p => p.Id);
            
            modelBuilder.Entity<Movimento>().HasKey(p => p.Id);

            
            modelBuilder.Entity<Carteira>().HasKey(p => p.Id);
            modelBuilder.Entity<Carteira>()
                .HasMany(p => p.Movimentos)
                .WithOne(p => p.Carteira);
            
            
            modelBuilder.Entity<Prontuario>().HasKey(p => p.Id);
            modelBuilder.Entity<Prontuario>().HasOne(p => p.Paciente).WithOne(p => p.Prontuario);
            modelBuilder.Entity<Prontuario>().HasOne(p => p.Psicologo);


            modelBuilder.Entity<Psicologo>().HasKey(p => p.Id);
            modelBuilder.Entity<Psicologo>().HasMany(p => p.Pacientes).WithOne(p => p.Psicologo);
            modelBuilder.Entity<Psicologo>().HasMany(p => p.Consultas).WithOne(p => p.Psicologo);
            modelBuilder.Entity<Psicologo>().HasOne(p => p.Carteira);



            modelBuilder.Entity<Paciente>().HasKey(p => p.Id);
            modelBuilder.Entity<Paciente>().HasOne(p => p.Psicologo).WithMany(p => p.Pacientes);
            modelBuilder.Entity<Paciente>().HasMany(p => p.Consultas).WithOne(p => p.Paciente);
            modelBuilder.Entity<Paciente>().HasOne(p => p.Endereco);
            modelBuilder.Entity<Paciente>()
                .HasOne(p => p.Prontuario)
                .WithOne(p => p.Paciente)
                .HasForeignKey<Prontuario>(p => p.Id)
                .IsRequired();
            modelBuilder.Entity<Paciente>().Property(p => p.Status)
                .HasConversion(
                    p => p.ToString(),
                    p => (StatusPaciente)Enum.Parse<StatusPaciente>(p));
                
            
            modelBuilder.Entity<Consulta>().HasKey(p => p.Id);
            modelBuilder.Entity<Consulta>().HasOne(p => p.Paciente).WithMany(p => p.Consultas);
            modelBuilder.Entity<Consulta>().HasOne(p => p.Psicologo).WithMany(p => p.Consultas);
            modelBuilder.Entity<Consulta>().Property(p => p.Status)
                .HasConversion(
                    p => p.ToString(),
                    p => (StatusConsulta)Enum.Parse<StatusConsulta>(p));

        }

        public DbSet<PsiConsulta.Models.Paciente> Paciente { get; set; }
        public DbSet<PsiConsulta.Models.Psicologo> Psicologo { get; set; }
        public DbSet<PsiConsulta.Models.Consulta> Consulta { get; set; }
        public DbSet<PsiConsulta.Models.Prontuario> Prontuario { get; set; }
        public DbSet<PsiConsulta.Models.Endereco> Endereco { get; set; }
        public DbSet<PsiConsulta.Models.Financiero.Carteira> Carteira { get; set; }
        public DbSet<PsiConsulta.Models.Financiero.Movimento> Movimento { get; set; }
        
    }
}
