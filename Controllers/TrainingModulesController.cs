using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Models.TrainingModule;
using EliteAthleteApp.Configurations.Constants;

namespace EliteAthleteApp.Controllers
{
	[Authorize]
	public class TrainingModulesController : Controller
	{
		private readonly ITrainingModuleRepository trainingModuleRepository;
		private readonly ITrainingOrmRepository trainingOrmRepository;

		public TrainingModulesController(ITrainingModuleRepository trainingModuleRepository, ITrainingOrmRepository trainingOrmRepository)
		{
			this.trainingModuleRepository = trainingModuleRepository;
			this.trainingOrmRepository = trainingOrmRepository;
		}

		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> Index(string? userId)
		{
			return View(await trainingModuleRepository.GetTrainingModuleIndexVMAsync(userId));
		}

		// GET: TrainingModules/TrainingModuleList
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> List(string userId)
		{
			return PartialView(await trainingModuleRepository.GetTrainingModuleVMsAsync(userId));
		}

		// GET: TrainingModules/Create
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator}")]
		public IActionResult Create(string userId, string coachId)
		{
			return PartialView(trainingModuleRepository.GetTrainingModuleCreateVM(userId, coachId));
		}

		// POST: TrainingModules/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator}")]
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
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator}")]
		public async Task<IActionResult> Edit(int trainingModuleId)
		{
			return PartialView(await trainingModuleRepository.GetTrainingModuleEditVMAsync(trainingModuleId));
		}

		// POST: TrainingModules/Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator}")]
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
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator}")]
		public async Task<IActionResult> Delete(int trainingModuleId)
		{
			return PartialView(await trainingModuleRepository.GetTrainingModuleDeleteVM(trainingModuleId));
		}

		// POST: TrainingModules/Delete
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator}")]
		public async Task<IActionResult> Delete(TrainingModuleDeleteVM trainingModuleDeleteVM)
		{
			await trainingModuleRepository.DeleteTrainingModuleAsync(trainingModuleDeleteVM.Id);
			return RedirectToAction(nameof(Index), "Users", new { userId = trainingModuleDeleteVM.UserId });
		}
	}
}
