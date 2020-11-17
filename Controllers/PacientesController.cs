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
        public IActionResult Index()
        {
            return View(_pacienteRepository.GetPacientes());
        }

        // GET: Pacientes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = _pacienteRepository.GetPacientes().FirstOrDefault(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // GET: Pacientes/Create
        public IActionResult Create()
        {
            var listaPsicologos = _psicologoRepository.GetPsicologos();
            var listStatus = Enum.GetValues(typeof(StatusPaciente)).Cast<StatusPaciente>().ToList();


            var viewModel = new PacienteFormViewModel { Status = listStatus, Psicologos = listaPsicologos };
            return View(viewModel);
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(/*[Bind("Profissao,Status,Id,CPF,Nome")]*/ Paciente paciente)
        {
            if (ModelState.IsValid){
                _pacienteRepository.SavePaciente(paciente);
                return RedirectToAction(nameof(Index));
            }

            //_pacienteRepository.SavePaciente(paciente);
            //return RedirectToAction(nameof(Index));

            return View(paciente);

        }

        // GET: Pacientes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = _pacienteRepository.GetPacientePorId(id);
            var listStatus = Enum.GetValues(typeof(StatusPaciente)).Cast<StatusPaciente>().ToList();
            var listaPsicologos = _psicologoRepository.GetPsicologos();

            var viewModel = new PacienteFormViewModel { Status = listStatus, Paciente = paciente, Psicologos = listaPsicologos };

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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paciente = await _context.Paciente.FindAsync(id);
            _context.Paciente.Remove(paciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(int id)
        {
            return _context.Paciente.Any(e => e.Id == id);
        }
    }
}
