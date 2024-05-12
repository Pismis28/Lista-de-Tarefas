using Microsoft.AspNetCore.Mvc;
using Projeto_Semana_4.Models;

namespace Projeto_Semana_4.Controllers
{
	public class TarefasController : Controller
	{
		private static List<Tarefas> _tarefas = new List<Tarefas>()
		{
			new Tarefas {CaminhoImagem = "img/program.jpg", TarefasID = 1, NomeTarefa = "Fazer projeto 4", Descricao = "Projeto da Impacta da semana 4", Data = DateTime.Now, Status = " Não Concluída"},
			new Tarefas {CaminhoImagem = "img/paying.jpg", TarefasID = 2, NomeTarefa = "Pagar contas", Descricao = "Pagar contas do mês de maio.", Data= DateTime.Now, Status = "Concluída"},
			new Tarefas {CaminhoImagem = "img/doctor.jpg", TarefasID = 3, NomeTarefa = "Consulta de Nicolas", Descricao = "Consulta mensal com o pediatra", Data=DateTime.Now, Status = "Não Concluída"},
		};

		public IActionResult Index()
		{
			return View(_tarefas);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Tarefas tarefas)
		{
			if (ModelState.IsValid)
			{
				tarefas.TarefasID = _tarefas.Count > 0 ? _tarefas.Max(c => c.TarefasID) + 1 : 1;
				_tarefas.Add(tarefas);
                return RedirectToAction("Index");
            }

			return View(tarefas);
		}

		public IActionResult Delete(int id)
		{
			var tarefas = _tarefas.FirstOrDefault(c => c.TarefasID == id);
			if (tarefas == null)
				return NotFound();

			_tarefas.Remove(tarefas);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var tarefas = _tarefas.FirstOrDefault(c => c.TarefasID == id);
			if (tarefas == null)
				return NotFound();

			return View(tarefas);
		}

		[HttpPost]
		public IActionResult Edit (Tarefas tarefas)
		{
			if (ModelState.IsValid)
			{
				var existingTarefas = _tarefas.FirstOrDefault(c => c.TarefasID == tarefas.TarefasID);
				if (existingTarefas != null)
				{
					existingTarefas.NomeTarefa = tarefas.NomeTarefa;
					existingTarefas.Descricao = tarefas.Descricao;
					existingTarefas.Status = tarefas.Status;
				}
				return RedirectToAction("Index");
			}
			return View(tarefas);
		}

		public IActionResult TarefasConcluidas()
		{
			var tarefasConcluidas = _tarefas.Where(t => t.Status == "Concluída").ToList();
			return View(tarefasConcluidas);
		}

	}
}