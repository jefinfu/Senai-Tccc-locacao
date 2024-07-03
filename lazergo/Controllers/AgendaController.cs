//Aqui vai controlar as movimentação das telas.

using lazergo.Dto;
using lazergo.Filtros;
using lazergo.Models;
using lazergo.Services.Agenda;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace lazergo.Controllers
{
    [UsuarioLogado]
    public class AgendaController : Controller
    {
        private readonly IAgendaInterface _agendaInterface;
        public AgendaController(IAgendaInterface agendaInterface) 
        { 
            _agendaInterface = agendaInterface;
        }
        public async Task<IActionResult> Index()
        {
            var agendaModels = await _agendaInterface.GetAgendas();
            return View(agendaModels);
        }


        public IActionResult Cadastrar() 
        {
            return View();
        }

        public async Task<IActionResult> Detalhes(int id)
        {
            var agenda = await _agendaInterface.GetAgendaPorId(id);
            if (agenda == null)
            {
                return NotFound();
            }
            return View(agenda);
        }


        public async Task<IActionResult>Editar(int id)
        {
            var agenda = await _agendaInterface.GetAgendaPorId(id);
            return View(agenda);
        }

        public async Task<IActionResult>Deletar(int id)
        {
            var agenda = await _agendaInterface.DeletarAgenda(id);
            return RedirectToAction("Index", "Agenda");
        }

        public async Task<IActionResult> Agendamento(int id)
        {
            var model = await _agendaInterface.GetAgendaPorId(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SalvarAgendamento(AgendaModel agenda)
        {
            if (ModelState.IsValid)
            {
                var agendamentoExistente = await _agendaInterface.GetAgendaPorId(agenda.Id);

                if (agendamentoExistente != null)
                {
                    agendamentoExistente.ProprietarioTer = agenda.ProprietarioTer;
                    agendamentoExistente.CelularTer = agenda.CelularTer;

                    await _agendaInterface.AtualizarAgenda(agendamentoExistente);

                    TempData["SuccessMessage"] = "Agendado com sucesso";
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(agenda);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(AgendaCriacaoDto agendaCriacaoDto, List<IFormFile> fotos)
        {
            if (ModelState.IsValid)
            {
                var agenda = await _agendaInterface.CriarAgenda(agendaCriacaoDto, fotos);
                return RedirectToAction("Editar", new { id = agenda.Id });
            }
            else
            {
                return View(agendaCriacaoDto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Editar(AgendaModel agendaModel, List<IFormFile>? fotos)
        {
            if (ModelState.IsValid)
            {
                var agenda = await _agendaInterface.EditarAgenda(agendaModel, fotos);
                return RedirectToAction("Detalhes", new { id = agenda.Id });
            }
            else
            {
                return View(agendaModel);
            }
        }
    }
}
