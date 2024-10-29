using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EliteAthleteApp.Constants;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Models.TrainingExercise;

namespace EliteAthleteApp.Controllers
{
	[Authorize(Roles = Roles.Administrator + "," + Roles.Coach)]
	public class TrainingExercisesController : Controller
	{
		private readonly ITrainingExerciseRepository exerciseRepository;

		public TrainingExercisesController(ITrainingExerciseRepository exerciseRepository)
		{
			this.exerciseRepository = exerciseRepository;
		}

		// GET: Exercises
		public async Task<IActionResult> Index()
		{
			return View(await exerciseRepository.GetExerciseIndexVMAsync());
		}

		// GET: Exercises/ExercisePublic
		public async Task<IActionResult> ExercisePublic()
		{
			return PartialView(await exerciseRepository.GetExerciseVMsAsync(null));
		}

		// GET: Exercises/ExercisePrivate
		public async Task<IActionResult> ExercisePrivate(string coachId)
		{
			return PartialView(await exerciseRepository.GetExerciseVMsAsync(coachId));
		}

		// GET: Exercises/Create
		public async Task<IActionResult> Create()
		{
			return PartialView(await exerciseRepository.GetExerciseCreateVMAsync());
		}

		// POST: Exercises/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(TrainingExerciseCreateVM exerciseCreateVM)
		{
			if (ModelState.IsValid)
			{
				await exerciseRepository.CreateExerciseAsync(exerciseCreateVM);
				return RedirectToAction(nameof(Index));
			}
			TempData["ErrorMessage"] = $"Error while creating the exercise. Please try again.";
			return RedirectToAction(nameof(Index));
		}

		// GET: Exercises/Edit
		public async Task<IActionResult> Edit(int id)
		{
			return PartialView(await exerciseRepository.GetExerciseEditVMAsync(id));
		}

		// POST: Exercises/Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(TrainingExerciseCreateVM exerciseCreateVM)
		{
			if (ModelState.IsValid)
			{
				await exerciseRepository.EditExerciseAsync(exerciseCreateVM);
				return RedirectToAction(nameof(Index));
			}
			TempData["ErrorMessage"] = $"Error while editing the exercise. Please try again.";
			return RedirectToAction(nameof(Index));
		}

		// GET: Exercises/Details
		public async Task<IActionResult> Details(int id)
		{
			return PartialView(await exerciseRepository.GetExerciseDetailsVMAsync(id));
		}

		// GET: Exercises/Delete
		public async Task<IActionResult> Delete(int id)
		{
			return PartialView(await exerciseRepository.GetExerciseDeleteVMAsync(id));
		}

		// POST: Exercises/Delete
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(TrainingExerciseDeleteVM trainingExerciseDeleteVM)
		{
			await exerciseRepository.DeleteExerciseAsync(trainingExerciseDeleteVM);
			return RedirectToAction(nameof(Index));
		}
	}
}
