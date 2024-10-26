using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using EliteAthleteApp.Constants;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models;
using EliteAthleteApp.Models.TrainingModule;
using EliteAthleteApp.Models.TrainingPlan;
using EliteAthleteApp.Repositories;

namespace EliteAthleteApp.Controllers
{
	public class TrainingModulesController : Controller
	{
		private readonly ITrainingModuleRepository trainingModuleRepository;

		public TrainingModulesController(ITrainingModuleRepository trainingModuleRepository)
		{
			this.trainingModuleRepository = trainingModuleRepository;
		}

		// GET: TrainingModules
		public async Task<IActionResult> Index(string userId)
		{
			var trainingModuleIndexVM = await trainingModuleRepository.GetTrainingModuleIndexVMAsync(userId);
			return View(trainingModuleIndexVM);
		}

		// GET: TrainingModules/TrainingModuleList
		public async Task<IActionResult> TrainingModuleList(string userId)
		{
			return PartialView(await trainingModuleRepository.GetTrainingModuleVMsAsync(userId));
		}

		// GET: TrainingModules/ORMList
		public async Task<IActionResult> ListORM(string userId)
		{
			return PartialView(await trainingModuleRepository.GetTrainingModuleORMVMsAsync(userId));
		}

		// GET: TrainingModules/Create
		public IActionResult Create(string userId, string coachId)
		{
			return PartialView(trainingModuleRepository.GetTrainingModuleCreateVM(userId, coachId));
		}

		// POST: TrainingModules/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = Roles.Administrator + "," + Roles.Coach + "," + Roles.Full)]
		public async Task<IActionResult> Create(TrainingModuleCreateVM trainingModuleCreateVM)
		{
			if (ModelState.IsValid)
			{
				await trainingModuleRepository.CreateTrainingModuleAsync(trainingModuleCreateVM);
				return RedirectToAction(nameof(Index), new { userId = trainingModuleCreateVM.UserId });
			}
			TempData["ErrorMessage"] = $"Error while creating the training module. Please try again.";
			return RedirectToAction(nameof(Index), new { userId = trainingModuleCreateVM.UserId });
		}

		// GET: TrainingModules/Edit
		public async Task<IActionResult> Edit(int trainingModuleId)
		{
			return PartialView(await trainingModuleRepository.GetTrainingModuleEditVMAsync(trainingModuleId));
		}

		// POST: TrainingModules/Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = Roles.Administrator + "," + Roles.Coach + "," + Roles.Full)]
		public async Task<IActionResult> Edit(TrainingModuleCreateVM trainingModuleCreateVM)
		{
			if (ModelState.IsValid)
			{
				await trainingModuleRepository.EditTrainingModuleAsync(trainingModuleCreateVM);
				return RedirectToAction(nameof(Index), new { userId = trainingModuleCreateVM.UserId });
			}
			TempData["ErrorMessage"] = $"Error while editing the training module. Please try again.";
			return RedirectToAction(nameof(Index), new { userId = trainingModuleCreateVM.UserId });
		}

		// GET: TrainingModules/Delete
		public IActionResult Delete(int trainingModuleId, string userId, string name)
		{
			return PartialView(trainingModuleRepository.GetTrainingModuleDeleteVM(trainingModuleId, name, userId));
		}

		// POST: TrainingModules/Delete
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = Roles.Administrator + "," + Roles.Coach + "," + Roles.Full)]
		public async Task<IActionResult> DeleteConfirmed(int id, string userId)
		{
			await trainingModuleRepository.DeleteTrainingModuleAsync(id);
			return RedirectToAction(nameof(Index), new { userId = userId });
		}

		// GET: TrainingModules/ORMCreate
		public IActionResult CreateORM(string userId)
		{
			return PartialView(trainingModuleRepository.GetTrainingModuleORMCreateVM(userId));
		}

		// POST: TrainingModules/ORM
		[HttpPost, ActionName("CreateORM")]
		public async Task<IActionResult> CreateORM(TrainingModuleORMCreateVM trainingModuleAddORMCreateVM)
		{
			await trainingModuleRepository.CreateORMAsync(trainingModuleAddORMCreateVM);
			return RedirectToAction(nameof(Index), new { userId = trainingModuleAddORMCreateVM.UserId });
		}
	}
}
