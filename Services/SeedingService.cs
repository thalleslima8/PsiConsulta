﻿using PsiConsulta.Context;
using PsiConsulta.Models;
using PsiConsulta.Models.Financiero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsiConsulta.Services
{
    public class SeedingService
    {
        private readonly PsiContext _context;

        public SeedingService(PsiContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Psicologo.Any() ||
                _context.Paciente.Any() ||
                _context.Consulta.Any() ||
                _context.Carteira.Any())
            {
                return; //DB está populado
            }

            Endereco end1 = new Endereco()
            {
                Logradouro = "Rua Estados Unidos",
                Complemento = "Qd. 21 Lt. 27",
                Bairro = "Vila Maria Luiza",
                Cep = "74.720-220",
                Municipio = "Goiânia",
                UF = "GO"
            };

            Endereco end2 = new Endereco()
            {
                Logradouro = "Av. W5",
                Complemento = "Residencial Solar Golden 1, Bloco G, Ap. 103",
                Bairro = "Sitios Santa Luzia",
                Cep = "74.922-685",
                Municipio = "Aparecida de Goiânia",
                UF = "GO"
            };

            Psicologo p1 = new Psicologo() {

                Nome = "Jessica Simonine",
                CPF = "00011122233",
                Telefone = "62 99242-6537",
                Email = "jessicasimonine@gmail.com",
                Carteira = new Carteira()
            };
            
            Psicologo p2 = new Psicologo() { 
                
                Nome = "Luana Priscila",
                CPF = "00011122244",
                Telefone = "62 93333-4444",
                Email = "luana@gmail.com",
                Carteira = new Carteira()
            };

            Psicologo p3 = new Psicologo()
            {
                
                Nome = "Nathalia Montes",
                CPF = "00011122255",
                Telefone = "62 92222-3333",
                Email = "montesnathalia@gmail.com",
                Carteira = new Carteira()
            };

            Psicologo p4 = new Psicologo()
            {
                
                Nome = "Natália Veloso",
                CPF = "00011122266",
                Telefone = "62 91111-2222",
                Email = "velosonatalia@gmail.com",
                Carteira = new Carteira()
            };

            Paciente a1 = new Paciente()
            {
                
                Nome = "Thalles Veloso",
                Profissao = "Engenheiro",
                Telefone = "62 99999-9999",
                CPF = "11122233344",
                Psicologo = p1,
                Endereco = end1,
            };

            Paciente a2 = new Paciente()
            {
                
                Nome = "Thalles Lima",
                Profissao = "Programador",
                Telefone = "62 99999-9999",
                CPF = "11122233355",
                Psicologo = p2,
                Endereco = end2,
            };

            Paciente a3 = new Paciente()
            {
                
                Nome = "Tiana Veloso",
                Profissao = "Pedagoga",
                Telefone = "62 99999-9999",
                CPF = "11122233366",
                Psicologo = p3,
                Endereco = end1,
            };

            Paciente a4 = new Paciente()
            {
                
                Nome = "Filipe Lima",
                Profissao = "Professor",
                Telefone = "62 99999-9999",
                CPF = "11122233377",
                Psicologo = p4,
                Endereco = end2,
            };

            Consulta c1 = new Consulta()
            {

                Paciente = a1,
                Psicologo = p1,
                Horario = new DateTime(2020, 11, 15, 14, 00, 00),
                Taxa = 180
            };

            Consulta c2 = new Consulta()
            {
               
                Paciente = a2,
                Psicologo = p2,
                Horario = new DateTime(2020, 11, 16, 17, 30, 00),
                Taxa = 80
            };

            Consulta c3 = new Consulta()
            {
                
                Paciente = a3,
                Psicologo = p3,
                Horario = new DateTime(2020, 11, 17, 08, 00, 00),
                Taxa = 150
            };

            Consulta c4 = new Consulta()
            {
                
                Paciente = a4,
                Psicologo = p4,
                Horario = new DateTime(2020, 11, 15, 10, 00, 00),
                Taxa = 70
            };

            _context.Endereco.AddRange(end1, end2);
            _context.Psicologo.AddRange(p1, p2, p3, p4);
            _context.Paciente.AddRange(a1, a2, a3, a4);
            _context.Consulta.AddRange(c1, c2, c3, c4);

            _context.SaveChanges();
        }
    }
}
