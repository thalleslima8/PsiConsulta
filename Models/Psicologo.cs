using PsiConsulta.Models.Financiero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsiConsulta.Models
{
    public class Psicologo : Pessoa
    {
        public Psicologo()
        {            
        }
        public List<Consulta> Consultas { get; set; }
        public List<Paciente> Pacientes { get; set; }
        public Carteira Carteira { get; set; }

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
            return Consultas;
        }


    }
}
