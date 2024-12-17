using EliteAthleteApp.Configurations.Constants;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Models.TrainingOrm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EliteAthleteApp.Controllers
{
	[Authorize]
	public class TrainingOrmsController : Controller
	{
		private readonly ITrainingOrmRepository trainingOrmRepository;

		public TrainingOrmsController(ITrainingOrmRepository trainingOrmRepository)
		{
			this.trainingOrmRepository = trainingOrmRepository;
		}

		// GET: TrainingOrm/List
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> List(string userId)
		{
			return PartialView(await trainingOrmRepository.GetTrainingOrmVMsAsync(userId));
		}

		// GET: TrainingOrm/Create
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> Create(string userId)
		{
			return PartialView(await trainingOrmRepository.GetTrainingOrmCreateVMAsync(userId));
		}

		// POST: TrainingOrm/Create
		[HttpPost, ActionName("Create")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> Create(TrainingOrmCreateVM trainingOrmCreateVM)
		{
			if (ModelState.IsValid)
			{
				await trainingOrmRepository.CreateOrmAsync(trainingOrmCreateVM);
				return RedirectToAction(nameof(Index), "Users", new { userId = trainingOrmCreateVM.UserId });
			}
			TempData["ErrorMessage"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).FirstOrDefault() ?? "Error while creating the ORM. Please try again.";
			return RedirectToAction(nameof(Index), "Users", new { userId = trainingOrmCreateVM.UserId });
		}

		// GET: TrainingOrm/Edit
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> Edit(int trainingOrmId)
		{
			return PartialView(await trainingOrmRepository.GetTrainingOrmEditVMAsync(trainingOrmId));
		}

		// POST: TrainingOrm/Edit
		[HttpPost, ActionName("Edit")]
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> Edit(TrainingOrmCreateVM trainingOrmCreateVM)
		{
			await trainingOrmRepository.EditOrmAsync(trainingOrmCreateVM);
			return RedirectToAction(nameof(Index), "Users", new { userId = trainingOrmCreateVM.UserId });
		}

		// GET: TrainingOrm/Delete
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> Delete(int trainingOrmId)
		{
			return PartialView(await trainingOrmRepository.GetTrainingOrmDeleteVMAsync(trainingOrmId));
		}

		// POST: TrainingOrm/Delete
		[HttpPost, ActionName("Delete")]
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator},{Roles.User}")]
		public async Task<IActionResult> Delete(TrainingOrmDeleteVM trainingOrmDeleteVM)
		{
			await trainingOrmRepository.DeleteOrmAsync(trainingOrmDeleteVM);
			return RedirectToAction(nameof(Index), "Users", new { userId = trainingOrmDeleteVM.UserId });
		}
	}
}
