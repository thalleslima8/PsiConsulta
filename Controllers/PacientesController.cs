using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PsiConsulta.Context;
using PsiConsulta.Models;
using PsiConsulta.Models.Enums;
using PsiConsulta.Models.ViewModels;
using PsiConsulta.Repositories;
using PsiConsulta.Services;

namespace PsiConsulta.Controllers
{
    public class PacientesController : Controller
    {
        private readonly PsiContext _context;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IPsicologoRepository _psicologoRepository;


        public PacientesController(PsiContext context, IPacienteRepository pacienteRepository, IPsicologoRepository psicologoRepository)
        {
            _context = context;
            _pacienteRepository = pacienteRepository;
            _psicologoRepository = psicologoRepository;
        }

        // GET: Pacientes
        public async Task<IActionResult> Index()
        {
            var listaPsicologos = await _psicologoRepository.GetPsicologos();
            var listStatus = Enum.GetValues(typeof(StatusPaciente)).Cast<StatusPaciente>().ToList();
            var listaPacientes = await _pacienteRepository.GetPacientes();

            var viewModel = new PacienteFormViewModel(_pacienteRepository)
            {
                Pacientes = listaPacientes,
                Status = listStatus,
                Psicologos = listaPsicologos
            };
            return View(viewModel);
        }

        // GET: Pacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _pacienteRepository.GetPacientePorId(id);
            if (paciente == null)
            {
                return NotFound();
            }

            var listaPsicologos = await _psicologoRepository.GetPsicologos();
            var listStatus = Enum.GetValues(typeof(StatusPaciente)).Cast<StatusPaciente>().ToList();
            var viewModel = new PacienteFormViewModel(_pacienteRepository)
            {
                Paciente = paciente,
                Status = listStatus,
                Psicologos = listaPsicologos
            };
            return View(viewModel);
        }

        // GET: Pacientes/Create
        public async Task<IActionResult> Create()
        {
            var listaPsicologos = await _psicologoRepository.GetPsicologos();
            var listStatus = Enum.GetValues(typeof(StatusPaciente)).Cast<StatusPaciente>().ToList();


            var viewModel = new PacienteFormViewModel(_pacienteRepository) { Status = listStatus, Psicologos = listaPsicologos };
            return View(viewModel);
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(/*[Bind("Profissao,Status,Id,CPF,Nome")]*/ Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _pacienteRepository.SavePaciente(paciente);
               return RedirectToAction(nameof(Index));
            }

            return View(paciente);
        }

        // GET: Pacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _pacienteRepository.GetPacientePorId(id);
            var listStatus = Enum.GetValues(typeof(StatusPaciente)).Cast<StatusPaciente>().ToList();
            var listaPsicologos = await _psicologoRepository.GetPsicologos();

            var viewModel = new PacienteFormViewModel(_pacienteRepository) { Status = listStatus, Paciente = paciente, Psicologos = listaPsicologos };

            return View(viewModel);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Paciente paciente)
        {

            if (id != paciente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _pacienteRepository.UpdatePaciente(paciente);
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = _pacienteRepository.GetPacientePorId(id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                await _pacienteRepository.RemovePaciente(id);
                return RedirectToAction(nameof(Index));
            }

            var paciente = await _pacienteRepository.GetPacientePorId(id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }
    }
}
