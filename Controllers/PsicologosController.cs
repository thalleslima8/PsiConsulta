using Microsoft.AspNetCore.Mvc;
using PsiConsulta.Models;
using PsiConsulta.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsiConsulta.Controllers
{
    public class PsicologosController : Controller
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IPsicologoRepository _psicologoRepository;

        public PsicologosController(IPacienteRepository pacienteRepository, IPsicologoRepository psicologoRepository)
        {
            _pacienteRepository = pacienteRepository;
            _psicologoRepository = psicologoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var psicologos = await _psicologoRepository.GetPsicologos();
            return View(psicologos);
        }

        // GET: Pacientes/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Psicologo psicologo)
        {
            if (ModelState.IsValid)
            {
                await _psicologoRepository.SavePsicologo(psicologo);
                return RedirectToAction("Index");
            }

            return View(psicologo);
        }

    }
}
