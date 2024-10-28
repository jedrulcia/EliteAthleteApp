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

		// GET: TrainingModules/ORMList
		public async Task<IActionResult> List(string userId)
		{
			return PartialView(await trainingOrmRepository.GetTrainingOrmVMsAsync(userId));
		}

		// GET: TrainingModules/ORMCreate
		public IActionResult Create(string userId)
		{
			return PartialView(trainingOrmRepository.GetTrainingOrmCreateVM(userId));
		}

		// POST: TrainingModules/ORM
		[HttpPost, ActionName("Create")]
		public async Task<IActionResult> Create(TrainingOrmCreateVM trainingModuleAddOrmCreateVM)
		{
			await trainingOrmRepository.CreateOrmAsync(trainingModuleAddOrmCreateVM);
			return RedirectToAction(nameof(Index), "TrainingModules", new { userId = trainingModuleAddOrmCreateVM.UserId });
		}
	}
}
