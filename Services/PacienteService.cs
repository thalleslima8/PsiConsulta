using PsiConsulta.Context;
using PsiConsulta.Models;
using PsiConsulta.Models.ViewModels;
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

        public Paciente ConverterFormEmPaciente(PacienteFormViewModel pacienteForm)
        {
            Paciente paciente = new Paciente();

            paciente.Nome = pacienteForm.Paciente.Nome;
            paciente.CPF = pacienteForm.Paciente.CPF;
            paciente.Telefone = pacienteForm.Paciente.Telefone;
            paciente.Profissao = pacienteForm.Paciente.Profissao;
            paciente.Endereco.Logradouro = pacienteForm.Paciente.Endereco.Logradouro;
            paciente.Endereco.Numero = pacienteForm.Paciente.Endereco.Numero;
            paciente.Endereco.Complemento = pacienteForm.Paciente.Endereco.Complemento;
            paciente.Endereco.Bairro = pacienteForm.Paciente.Endereco.Bairro;
            paciente.Endereco.Municipio = pacienteForm.Paciente.Endereco.Municipio;
            paciente.Endereco.Cep = pacienteForm.Paciente.Endereco.Cep;
            paciente.Endereco.UF = pacienteForm.Paciente.Endereco.UF;
            paciente.Psicologo = pacienteForm.Paciente.Psicologo;

            return paciente;
        }
    }
}
