using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EliteAthleteApp.Constants;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Models.TrainingModule;

namespace EliteAthleteApp.Controllers
{
	public class TrainingModulesController : Controller
	{
		private readonly ITrainingModuleRepository trainingModuleRepository;
		private readonly ITrainingOrmRepository trainingOrmRepository;

		public TrainingModulesController(ITrainingModuleRepository trainingModuleRepository, ITrainingOrmRepository trainingOrmRepository)
		{
			this.trainingModuleRepository = trainingModuleRepository;
			this.trainingOrmRepository = trainingOrmRepository;
		}

		// GET: TrainingModules/TrainingModuleList
		public async Task<IActionResult> List(string userId)
		{
			return PartialView(await trainingModuleRepository.GetTrainingModuleVMsAsync(userId));
		}

		// GET: TrainingModules/Create
		public IActionResult Create(string userId, string coachId)
		{
			return PartialView(trainingModuleRepository.GetTrainingModuleCreateVM(userId, coachId));
		}

		// POST: TrainingModules/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(TrainingModuleCreateVM trainingModuleCreateVM)
		{
			if (ModelState.IsValid)
			{
				await trainingModuleRepository.CreateTrainingModuleAsync(trainingModuleCreateVM);
				return RedirectToAction(nameof(Index), "Users", new { userId = trainingModuleCreateVM.UserId });
			}
			TempData["ErrorMessage"] = ModelState.Values
				.SelectMany(v => v.Errors)
				.Select(e => e.ErrorMessage)
				.FirstOrDefault() ?? "Error while creating the Training Module. Please try again.";
			return RedirectToAction(nameof(Index), "Users", new { userId = trainingModuleCreateVM.UserId });
		}

		// GET: TrainingModules/Edit
		public async Task<IActionResult> Edit(int trainingModuleId)
		{
			return PartialView(await trainingModuleRepository.GetTrainingModuleEditVMAsync(trainingModuleId));
		}

		// POST: TrainingModules/Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(TrainingModuleCreateVM trainingModuleCreateVM)
		{
			if (ModelState.IsValid)
			{
				await trainingModuleRepository.EditTrainingModuleAsync(trainingModuleCreateVM);
				return RedirectToAction(nameof(Index), "Users", new { userId = trainingModuleCreateVM.UserId });
			}
			TempData["ErrorMessage"] = ModelState.Values
				.SelectMany(v => v.Errors)
				.Select(e => e.ErrorMessage)
				.FirstOrDefault() ?? "Error while editing the Training Module. Please try again.";
			return RedirectToAction(nameof(Index), "Users", new { userId = trainingModuleCreateVM.UserId });
		}

		// GET: TrainingModules/Delete
		public async Task<IActionResult> Delete(int trainingModuleId)
		{
			return PartialView(await trainingModuleRepository.GetTrainingModuleDeleteVM(trainingModuleId));
		}

		// POST: TrainingModules/Delete
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(TrainingModuleDeleteVM trainingModuleDeleteVM)
		{
			await trainingModuleRepository.DeleteTrainingModuleAsync(trainingModuleDeleteVM.Id);
			return RedirectToAction(nameof(Index), "Users", new { userId = trainingModuleDeleteVM.UserId });
		}
	}
}
