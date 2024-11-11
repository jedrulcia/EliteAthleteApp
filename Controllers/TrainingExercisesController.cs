using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EliteAthleteApp.Constants;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Models.TrainingExercise;
using AutoMapper;
using EliteAthleteApp.Models.Admin;
using EliteAthleteApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace EliteAthleteApp.Controllers
{
	public class TrainingExercisesController : Controller
	{
		private readonly ITrainingExerciseRepository exerciseRepository;
		private readonly IMapper mapper;

		public TrainingExercisesController(ITrainingExerciseRepository exerciseRepository, IMapper mapper)
		{
			this.exerciseRepository = exerciseRepository;
			this.mapper = mapper;
		}

		// GET: Exercises
		public async Task<IActionResult> Index(int? exerciseMediaId)
		{
			return View(await exerciseRepository.GetExerciseIndexVMAsync(exerciseMediaId));
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

		// GET: Admin/Index/ExerciseAdmin
		public async Task<IActionResult> ExerciseAdmin()
		{
			var exerciseVMs = await exerciseRepository.GetAdminExerciseVMsAsync();

			return PartialView(exerciseVMs);
		}

		// GET: Admin/Index/ExerciseAsPublic
		public async Task<IActionResult> ExerciseAsPublic(int trainingExerciseId)
		{
			var exerciseVM = mapper.Map<TrainingExerciseVM>(await exerciseRepository.GetAsync(trainingExerciseId));
			return PartialView(new AdminSetExerciseAsPublicVM { TrainingExerciseVM = exerciseVM });
		}

		// POST: Admin/Index/SetExerciseAsPublic
		[HttpPost, ActionName("ExerciseAsPublic")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ExerciseAsPublicPost(int trainingExerciseId)
		{
			var exercise = await exerciseRepository.GetAsync(trainingExerciseId);
			exercise.CoachId = null;
			exercise.SetAsPublic = true;
			await exerciseRepository.UpdateAsync(exercise);
			return RedirectToAction(nameof(Index), "Admin");
		}

		// GET: Exercises/Create
		public async Task<IActionResult> Create(int? privateExerciseCount)
		{
			return PartialView(await exerciseRepository.GetExerciseCreateVMAsync(privateExerciseCount));
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
