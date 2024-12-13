﻿using EliteAthleteApp.Contracts;
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
			return PartialView(await trainingOrmRepository.GetTrainingOrmCreateVMAsync(userId));
		}

		// POST: TrainingOrm/Create
		[HttpPost, ActionName("Create")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(TrainingOrmCreateVM trainingOrmCreateVM)
		{
			if (ModelState.IsValid)
			{
				await trainingOrmRepository.CreateOrmAsync(trainingOrmCreateVM);
				return RedirectToAction(nameof(Index), "Users", new { userId = trainingOrmCreateVM.UserId });
			}
			TempData["ErrorMessage"] = ModelState.Values
				.SelectMany(v => v.Errors)
				.Select(e => e.ErrorMessage)
				.FirstOrDefault() ?? "Error while creating the ORM. Please try again.";
			return RedirectToAction(nameof(Index), "Users", new { userId = trainingOrmCreateVM.UserId });
		}

		// GET: TrainingOrm/Edit
		public async Task<IActionResult> Edit(int trainingOrmId)
		{
			var trainingOrm = await trainingOrmRepository.GetTrainingOrmEditVMAsync(trainingOrmId);
			return PartialView(trainingOrm);
		}

		// POST: TrainingOrm/Edit
		[HttpPost, ActionName("Edit")]
		public async Task<IActionResult> Edit(TrainingOrmCreateVM trainingOrmCreateVM)
		{
			await trainingOrmRepository.EditOrmAsync(trainingOrmCreateVM);
			return RedirectToAction(nameof(Index), "Users", new { userId = trainingOrmCreateVM.UserId });
		}
		
		// GET: TrainingOrm/Delete
		public async Task<IActionResult> Delete(int trainingOrmId)
		{
			return PartialView(await trainingOrmRepository.GetTrainingOrmDeleteVMAsync(trainingOrmId));
		}

		// POST: TrainingOrm/Delete
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> Delete(TrainingOrmDeleteVM trainingOrmDeleteVM)
		{
			await trainingOrmRepository.DeleteOrmAsync(trainingOrmDeleteVM);
			return RedirectToAction(nameof(Index), "Users", new { userId = trainingOrmDeleteVM.UserId });
		}
	}
}
