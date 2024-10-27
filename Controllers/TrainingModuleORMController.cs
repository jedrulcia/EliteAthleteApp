using EliteAthleteApp.Contracts;
using EliteAthleteApp.Models.TrainingModule;
using Microsoft.AspNetCore.Mvc;

namespace EliteAthleteApp.Controllers
{
	public class TrainingModuleORMController : Controller
	{
		private readonly ITrainingModuleORMRepository trainingModuleORMRepository;

		public TrainingModuleORMController(ITrainingModuleORMRepository trainingModuleORMRepository)
		{
			this.trainingModuleORMRepository = trainingModuleORMRepository;
		}

		// GET: TrainingModules/ORMList
		public async Task<IActionResult> List(string userId)
		{
			return PartialView(await trainingModuleORMRepository.GetTrainingModuleORMVMsAsync(userId));
		}

		// GET: TrainingModules/ORMCreate
		public IActionResult Create(string userId)
		{
			return PartialView(trainingModuleORMRepository.GetTrainingModuleORMCreateVM(userId));
		}

		// POST: TrainingModules/ORM
		[HttpPost, ActionName("Create")]
		public async Task<IActionResult> Create(TrainingModuleORMCreateVM trainingModuleAddORMCreateVM)
		{
			await trainingModuleORMRepository.CreateORMAsync(trainingModuleAddORMCreateVM);
			return RedirectToAction(nameof(Index), "TrainingModules", new { userId = trainingModuleAddORMCreateVM.UserId });
		}
	}
}
