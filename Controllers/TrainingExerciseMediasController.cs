using EliteAthleteApp.Contracts;
using EliteAthleteApp.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EliteAthleteApp.Controllers
{
	public class TrainingExerciseMediasController : Controller
	{
		private readonly ITrainingExerciseMediaRepository trainingExerciseMediaRepository;

		public TrainingExerciseMediasController(ITrainingExerciseMediaRepository trainingExerciseMediaRepository)
		{
			this.trainingExerciseMediaRepository = trainingExerciseMediaRepository;
		}
		// GET: TrainingExerciseMedia/Edit
		public async Task<IActionResult> Edit(int trainingExerciseMediaId)
		{
			return PartialView(await trainingExerciseMediaRepository.GetTrainingExerciseMediaEditVMAsync(trainingExerciseMediaId));
		}
	}
}
