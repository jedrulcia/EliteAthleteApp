using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using TrainingPlanApp.Web.Contracts;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;
using TrainingPlanApp.Web.Models.TrainingModule;
using TrainingPlanApp.Web.Models.TrainingPlan;
using TrainingPlanApp.Web.Repositories;

namespace TrainingPlanApp.Web.Controllers
{
	public class TrainingModulesController : Controller
	{
		private readonly ApplicationDbContext context;
		private readonly UserManager<User> userManager;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly ITrainingModuleRepository trainingModuleRepository;
		private readonly IMapper mapper;

		public TrainingModulesController(ApplicationDbContext context,
			UserManager<User> userManager,
			IHttpContextAccessor httpContextAccessor,
			ITrainingModuleRepository trainingModuleRepository,
			IMapper mapper)
		{
			this.context = context;
			this.userManager = userManager;
			this.httpContextAccessor = httpContextAccessor;
			this.trainingModuleRepository = trainingModuleRepository;
			this.mapper = mapper;
		}

		// GET: TrainingModules
		public async Task<IActionResult> Index(string userId)
		{
			if (userId == null)
			{
				var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
				userId = user.Id;
			}
			var trainingModuleIndexVM = await trainingModuleRepository.GetUserTrainingModuleIndexVM(userId);
			return View(trainingModuleIndexVM);
		}

		// POST: TrainingModules/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(TrainingModuleCreateVM trainingModuleCreateVM)
		{
			if (ModelState.IsValid)
			{
				await trainingModuleRepository.CreateTrainingModule(trainingModuleCreateVM);
				return RedirectToAction(nameof(Index), new { userId = trainingModuleCreateVM.UserId });
			}

			TempData["ErrorMessage"] = $"Error while creating the training module. Please try again.";
			return RedirectToAction(nameof(Index), new { userId = trainingModuleCreateVM.UserId });
		}

		// POST: TrainingModules/Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(TrainingModuleCreateVM trainingModuleCreateVM)
		{
			if (ModelState.IsValid)
			{
				await trainingModuleRepository.EditTrainingModule(trainingModuleCreateVM);
				return RedirectToAction(nameof(Index), new { userId = trainingModuleCreateVM.UserId });
			}

			TempData["ErrorMessage"] = $"Error while editing the training module. Please try again.";
			return RedirectToAction(nameof(Index), new { userId = trainingModuleCreateVM.UserId });
		}

		// POST: TrainingModules/Delete
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id, string userId)
		{
			await trainingModuleRepository.DeleteTrainingModule(id);
			return RedirectToAction(nameof(Index), new { userId = userId });
		}

	}
}
