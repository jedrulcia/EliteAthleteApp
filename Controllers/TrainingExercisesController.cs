using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Models.TrainingExercise;
using AutoMapper;
using EliteAthleteApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using EliteAthleteApp.Data;

namespace EliteAthleteApp.Controllers
{
	public class TrainingExercisesController : Controller
	{
		private readonly ITrainingExerciseRepository trainingExerciseRepository;
		private readonly IMapper mapper;
		private readonly ITrainingExerciseMediaRepository trainingExerciseMediaRepository;

		public TrainingExercisesController(ITrainingExerciseRepository trainingExerciseRepository, IMapper mapper, ITrainingExerciseMediaRepository trainingExerciseMediaRepository)
		{
			this.trainingExerciseRepository = trainingExerciseRepository;
			this.mapper = mapper;
			this.trainingExerciseMediaRepository = trainingExerciseMediaRepository;
		}

		// GET: Exercises
		public async Task<IActionResult> Index(int? exerciseMediaId)
		{
			return View(await trainingExerciseRepository.GetExerciseIndexVMAsync(exerciseMediaId));
		}

		// GET: Exercises/ExercisePublic
		public async Task<IActionResult> ExercisePublic()
		{
			return PartialView(await trainingExerciseRepository.GetExerciseVMsAsync(null));
		}

		// GET: Exercises/ExercisePrivate
		public async Task<IActionResult> ExercisePrivate(string coachId)
		{
			return PartialView(await trainingExerciseRepository.GetExerciseVMsAsync(coachId));
		}

		// GET: AdminIndex/ExerciseAdmin
		public async Task<IActionResult> ExerciseAdmin()
		{
			return PartialView(await trainingExerciseRepository.GetExerciseAdminVMsAsync());
		}

		// GET: AdminIndex/ExerciseAsPublic
		public async Task<IActionResult> ExerciseAsPublic(int trainingExerciseId)
		{
			return PartialView(await trainingExerciseRepository.GetExerciseAsPublicVMAsync(trainingExerciseId));
		}

		// POST: AdminIndex/SetExerciseAsPublic
		[ValidateAntiForgeryToken]
		[HttpPost, ActionName("ExerciseAsPublic")]
		public async Task<IActionResult> ExerciseAsPublicPost(int trainingExerciseId)
		{
			await trainingExerciseRepository.SetExerciseAsPublic(trainingExerciseId);
			return RedirectToAction(nameof(Index), "Users");
		}

		// GET: Exercises/Create
		public async Task<IActionResult> Create(int? privateExerciseCount)
		{
			return PartialView(await trainingExerciseRepository.GetExerciseCreateVMAsync(privateExerciseCount));
		}

		// POST: Exercises/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(TrainingExerciseCreateVM exerciseCreateVM)
		{
			if (ModelState.IsValid)
			{
				await trainingExerciseRepository.CreateExerciseAsync(exerciseCreateVM);
				return RedirectToAction(nameof(Index));
			}
			TempData["ErrorMessage"] = ModelState.Values
				.SelectMany(v => v.Errors)
				.Select(e => e.ErrorMessage)
				.FirstOrDefault() ?? "Error while creating the Exercise. Please try again.";
			return RedirectToAction(nameof(Index));
		}

		// GET: Exercises/Edit
		public async Task<IActionResult> Edit(int id)
		{
			return PartialView(await trainingExerciseRepository.GetExerciseEditVMAsync(id));
		}

		// POST: Exercises/Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(TrainingExerciseCreateVM exerciseCreateVM)
		{
			if (ModelState.IsValid)
			{
				await trainingExerciseRepository.EditExerciseAsync(exerciseCreateVM);
				return RedirectToAction(nameof(Index));
			}
			TempData["ErrorMessage"] = ModelState.Values
				.SelectMany(v => v.Errors)
				.Select(e => e.ErrorMessage)
				.FirstOrDefault() ?? "Error while Editing the Exercise. Please try again.";
			return RedirectToAction(nameof(Index));
		}

		// GET: Exercises/Details
		public async Task<IActionResult> Details(int id)
		{
			return PartialView(await trainingExerciseRepository.GetExerciseDetailsVMAsync(id));
		}

		// GET: Exercises/Delete
		public async Task<IActionResult> Delete(int id)
		{
			return PartialView(await trainingExerciseRepository.GetExerciseDeleteVMAsync(id));
		}

		// POST: Exercises/Delete
		[ValidateAntiForgeryToken]
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(TrainingExerciseDeleteVM trainingExerciseDeleteVM)
		{
			await trainingExerciseRepository.DeleteExerciseAsync(trainingExerciseDeleteVM);
			return RedirectToAction(nameof(Index));
		}


		// GET: TrainingExercise/Edit
		public async Task<IActionResult> EditMedia(int exerciseMediaId)
		{
			return PartialView(await trainingExerciseMediaRepository.GetTrainingExerciseMediaCreateVMAsync(exerciseMediaId));
		}

		// POST: TrainingExercise/EditMedia/UploadImage
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UploadImage(int index, int id)
		{
			var imageFile = Request.Form.Files[$"imageUpload"];
			await trainingExerciseMediaRepository.UploadImageAsync(id, index, imageFile);
			return RedirectToAction(nameof(Index), "TrainingExercises");
		}

		// POST: TrainingExerciseMedia/EditMedia/UploadVideo
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UploadVideo(int id)
		{
			var videoFile = Request.Form.Files[$"videoUpload"];
			await trainingExerciseMediaRepository.UploadVideoAsync(id, videoFile);
			return RedirectToAction(nameof(Index), "TrainingExercises");
		}

		// POST: TrainingExerciseMedia/EditMedia/DeleteImage
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteImage(int index, int id)
		{
			await trainingExerciseMediaRepository.DeleteImageAsync(id, index);
			return RedirectToAction(nameof(Index), "TrainingExercises");
		}

		// POST: TrainingExerciseMedia/EditMedia/DeleteVideo
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteVideo(int id)
		{
			await trainingExerciseMediaRepository.DeleteVideoAsync(id);
			return RedirectToAction(nameof(Index), "TrainingExercises");
		}
	}
}
