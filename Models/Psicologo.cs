using PsiConsulta.Models.Financiero;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PsiConsulta.Models
{
    public class Psicologo : Pessoa
    {
        public Psicologo()
        {
            Carteira = new Carteira();
        }

        public List<Consulta> Consultas { get; set; }
        public List<Paciente> Pacientes { get; set; }
        public Carteira Carteira { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Telefone { get; set; }

        public void adicionaPaciente(Paciente paciente)
        {
            Pacientes.Add(paciente);
        }

        public List<Paciente> GetPacientes()
        {
            return Pacientes;
        }
        
        public List<Consulta> GetConsultas()
        {
            return Consultas.OrderBy(p => p.Horario).ToList();
        }


    }
}
