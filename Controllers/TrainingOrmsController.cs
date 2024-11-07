using EliteAthleteApp.Contracts;
using EliteAthleteApp.Models.TrainingOrm;
using Microsoft.AspNetCore.Mvc;

namespace EliteAthleteApp.Controllers
{
    public class TrainingOrmsController : Controller
	{
		private readonly ITrainingOrmRepository trainingOrmRepository;

		public TrainingOrmsController(ITrainingOrmRepository trainingOrmRepository)
		{
			this.trainingOrmRepository = trainingOrmRepository;
		}

		// GET: TrainingOrm/List
		public async Task<IActionResult> List(string userId)
		{
			return PartialView(await trainingOrmRepository.GetTrainingOrmVMsAsync(userId));
		}

		// GET: TrainingOrm/Create
		public async Task<IActionResult> Create(string userId)
		{
			return PartialView(await trainingOrmRepository.GetTrainingOrmCreateVM(userId));
		}

		// POST: TrainingOrm/Create
		[HttpPost, ActionName("Create")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(TrainingOrmCreateVM trainingOrmCreateVM)
		{
			if (ModelState.IsValid)
			{
				await trainingOrmRepository.CreateOrmAsync(trainingOrmCreateVM);
				return RedirectToAction("Panel", "Users", new { userId = trainingOrmCreateVM.UserId });
			}
			TempData["ErrorMessage"] = $"Error while creating ORM. Please try again.";
			return RedirectToAction("Panel", "Users", new { userId = trainingOrmCreateVM.UserId });
		}

		// GET: TrainingOrm/Edit
		public async Task<IActionResult> Edit(int trainingOrmId)
		{
			var trainingOrm = await trainingOrmRepository.GetTrainingOrmEditVM(trainingOrmId);
			return PartialView(trainingOrm);
		}

		// POST: TrainingOrm/Edit
		[HttpPost, ActionName("Edit")]
		public async Task<IActionResult> Edit(TrainingOrmCreateVM trainingOrmCreateVM)
		{
			await trainingOrmRepository.EditOrmAsync(trainingOrmCreateVM);
			return RedirectToAction("Panel", "Users", new { userId = trainingOrmCreateVM.UserId });
		}
		
		// GET: TrainingOrm/Delete
		public async Task<IActionResult> Delete(int trainingOrmId)
		{
			return PartialView(await trainingOrmRepository.GetTrainingOrmDeleteVM(trainingOrmId));
		}

		// POST: TrainingOrm/Delete
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> Delete(TrainingOrmDeleteVM trainingOrmDeleteVM)
		{
			await trainingOrmRepository.DeleteOrmAsync(trainingOrmDeleteVM);
			return RedirectToAction("Panel", "Users", new { userId = trainingOrmDeleteVM.UserId });
		}
	}
}
