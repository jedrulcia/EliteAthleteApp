﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EliteAthleteAppShared.Contracts;
using EliteAthleteAppShared.Models.TrainingExercise;
using EliteAthleteAppShared.Configurations.Constants;
using AutoMapper;
using EliteAthleteAppShared.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using EliteAthleteAppShared.Data;

namespace EliteAthleteApp.Controllers
{
	[Authorize]
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
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator}")]
		public async Task<IActionResult> Index(int? exerciseMediaId)
		{
			return View(await trainingExerciseRepository.GetExerciseIndexVMAsync(exerciseMediaId));
		}

		// GET: Exercises/ExercisePublic
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator}")]
		public async Task<IActionResult> ExercisePublic()
		{
			return PartialView(await trainingExerciseRepository.GetExerciseVMsAsync(null));
		}

		// GET: Exercises/ExercisePrivate
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator}")]
		public async Task<IActionResult> ExercisePrivate(string coachId)
		{
			return PartialView(await trainingExerciseRepository.GetExerciseVMsAsync(coachId));
		}

		// GET: AdminIndex/ExerciseAdmin
		[Authorize(Roles = Roles.Administrator)]
		public async Task<IActionResult> ExerciseAdmin()
		{
			return PartialView(await trainingExerciseRepository.GetExerciseAdminVMsAsync());
		}

		// GET: AdminIndex/ExerciseAsPublic
		[Authorize(Roles = Roles.Administrator)]
		public async Task<IActionResult> ExerciseAsPublic(int trainingExerciseId)
		{
			return PartialView(await trainingExerciseRepository.GetExerciseAsPublicVMAsync(trainingExerciseId));
		}

		// POST: AdminIndex/SetExerciseAsPublic
		[ValidateAntiForgeryToken]
		[HttpPost, ActionName("ExerciseAsPublic")]
		[Authorize(Roles = Roles.Administrator)]
		public async Task<IActionResult> ExerciseAsPublicPost(int trainingExerciseId)
		{
			await trainingExerciseRepository.SetExerciseAsPublic(trainingExerciseId);
			return RedirectToAction(nameof(Index), "Users");
		}

		// GET: Exercises/Create
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator}")]
		public async Task<IActionResult> Create(int? privateExerciseCount)
		{
			return PartialView(await trainingExerciseRepository.GetExerciseCreateVMAsync(privateExerciseCount));
		}

		// POST: Exercises/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator}")]
		public async Task<IActionResult> Create(TrainingExerciseCreateVM exerciseCreateVM)
		{
			if (ModelState.IsValid)
			{
				await trainingExerciseRepository.CreateExerciseAsync(exerciseCreateVM);
				return RedirectToAction(nameof(Index));
			}
			TempData["ErrorMessage"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).FirstOrDefault() ?? "Error while creating the Exercise. Please try again.";
			return RedirectToAction(nameof(Index));
		}

		// GET: Exercises/Edit
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator}")]
		public async Task<IActionResult> Edit(int id)
		{
			return PartialView(await trainingExerciseRepository.GetExerciseEditVMAsync(id));
		}

		// POST: Exercises/Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator}")]
		public async Task<IActionResult> Edit(TrainingExerciseCreateVM exerciseCreateVM)
		{
			if (ModelState.IsValid)
			{
				await trainingExerciseRepository.EditExerciseAsync(exerciseCreateVM);
				return RedirectToAction(nameof(Index));
			}
			TempData["ErrorMessage"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).FirstOrDefault() ?? "Error while Editing the Exercise. Please try again.";
			return RedirectToAction(nameof(Index));
		}

		// GET: Exercises/Details
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator}")]
		public async Task<IActionResult> Details(int id)
		{
			return PartialView(await trainingExerciseRepository.GetExerciseDetailsVMAsync(id));
		}

		// GET: Exercises/Delete
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator}")]
		public async Task<IActionResult> Delete(int id)
		{
			return PartialView(await trainingExerciseRepository.GetExerciseDeleteVMAsync(id));
		}

		// POST: Exercises/Delete
		[ValidateAntiForgeryToken]
		[HttpPost, ActionName("Delete")]
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator}")]
		public async Task<IActionResult> DeleteConfirmed(TrainingExerciseDeleteVM trainingExerciseDeleteVM)
		{
			await trainingExerciseRepository.DeleteExerciseAsync(trainingExerciseDeleteVM);
			return RedirectToAction(nameof(Index));
		}


		// GET: TrainingExercise/Edit
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator}")]
		public async Task<IActionResult> EditMedia(int exerciseMediaId)
		{
			return PartialView(await trainingExerciseMediaRepository.GetTrainingExerciseMediaCreateVMAsync(exerciseMediaId));
		}

		// POST: TrainingExercise/EditMedia/UploadImage
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator}")]
		public async Task<IActionResult> UploadImage(int index, int id)
		{
			var imageFile = Request.Form.Files[$"imageUpload"];
			await trainingExerciseMediaRepository.UploadImageAsync(id, index, imageFile);
			return RedirectToAction(nameof(Index), "TrainingExercises");
		}

		// POST: TrainingExerciseMedia/EditMedia/UploadVideo
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator}")]
		public async Task<IActionResult> UploadVideo(int id)
		{
			var videoFile = Request.Form.Files[$"videoUpload"];
			await trainingExerciseMediaRepository.UploadVideoAsync(id, videoFile);
			return RedirectToAction(nameof(Index), "TrainingExercises");
		}

		// POST: TrainingExerciseMedia/EditMedia/DeleteImage
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator}")]
		public async Task<IActionResult> DeleteImage(int index, int id)
		{
			await trainingExerciseMediaRepository.DeleteImageAsync(id, index);
			return RedirectToAction(nameof(Index), "TrainingExercises");
		}

		// POST: TrainingExerciseMedia/EditMedia/DeleteVideo
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = $"{Roles.Coach},{Roles.Administrator}")]
		public async Task<IActionResult> DeleteVideo(int id)
		{
			await trainingExerciseMediaRepository.DeleteVideoAsync(id);
			return RedirectToAction(nameof(Index), "TrainingExercises");
		}
	}
}
