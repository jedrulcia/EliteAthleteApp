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
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Configuration.UserSecrets;
using TrainingPlanApp.Web.Constants;
using TrainingPlanApp.Web.Contracts;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;
using TrainingPlanApp.Web.Models.TrainingPlan;
using TrainingPlanApp.Web.Repositories;

namespace TrainingPlanApp.Web.Controllers
{
    public class TrainingPlansController : Controller
	{
		private readonly ITrainingPlanRepository trainingPlanRepository;
		private readonly IMapper mapper;
		private readonly IExerciseRepository exerciseRepository;
		private readonly UserManager<User> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ApplicationDbContext context;

        public TrainingPlansController(ApplicationDbContext context,
			ITrainingPlanRepository trainingPlanRepository,
			IMapper mapper,
			IExerciseRepository exerciseRepository,
			UserManager<User> userManager,
			IHttpContextAccessor httpContextAccessor)
		{
			this.mapper = mapper;
			this.exerciseRepository = exerciseRepository;
			this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
            this.trainingPlanRepository = trainingPlanRepository;
			this.context = context;
		}

		// GET: TrainingPlans
		public async Task<IActionResult> Index(string userId, List<int?>? trainingPlanIds)
		{
			if (userId == null)
			{
                var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
				userId = user.Id;
            }
			var trainingPlanIndexVM = await trainingPlanRepository.GetModuleTrainingPlans(trainingPlanIds); 
			ViewBag.UserId = userId;
			ViewBag.UserVM = mapper.Map<UserVM>(await userManager.FindByIdAsync(userId));
			return View(trainingPlanIndexVM);
		}

		// GET: TrainingPlans/Details
		public async Task<IActionResult> Details(int? id)
		{
			var trainingPlan = await trainingPlanRepository.GetAsync(id);
			if (trainingPlan == null)
			{
				return NotFound();
			}
			var trainingPlanDetailsVM = await trainingPlanRepository.GetTrainingPlanDetailsVM(trainingPlan);
			return View(trainingPlanDetailsVM);
		}

		// GET: TrainingPlans/Create
		[Authorize(Roles = Roles.Administrator)]
		public IActionResult Create(string? userId)
		{
			var trainingPlanCreateVM = new TrainingPlanCreateVM
			{
				UserId = userId
			};
			return View(trainingPlanCreateVM);
		}

		// POST: TrainingPlans/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = Roles.Administrator)]
		public async Task<IActionResult> Create(TrainingPlanCreateVM model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await trainingPlanRepository.CreateTrainingPlan(model);
					return RedirectToAction(nameof(Index), new { userId = model.UserId });
				}
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, "An error has occurred. Please try again later");
			}
			return View(model);
		}

		// GET: TrainingPlans/ManageExercises
		[Authorize(Roles = Roles.Administrator)]
		public async Task<IActionResult> ManageExercises(int? id)
		{
			var trainingPlanManageExercisesVM = await trainingPlanRepository.GetTrainingPlanManageExercisesVM(id);
			return View(trainingPlanManageExercisesVM);
		}

		// POST: TrainingPlans/ManageExercises
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = Roles.Administrator)]
		public async Task<IActionResult> ManageExercises(TrainingPlanManageExercisesVM trainingPlanAddExercisesVM)
		{
			return View(await trainingPlanRepository.AddExerciseToTrainingPlan(trainingPlanAddExercisesVM));
		}

		[Authorize(Roles = Roles.Administrator)]
		public async Task<IActionResult> ChangeStatus(int id, bool status, string userId)
		{
			await trainingPlanRepository.ChangeTrainingPlanStatus(id, status);
			return RedirectToAction(nameof(Index), new { userId = userId });
		}

		// GET: TrainingPlans/Edit
		[Authorize(Roles = Roles.Administrator)]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var trainingPlanCreateVM = mapper.Map<TrainingPlanCreateVM>(await trainingPlanRepository.GetAsync(id));
			return View(trainingPlanCreateVM);
		}

		// POST: TrainingPlans/Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = Roles.Administrator)]
		public async Task<IActionResult> Edit(TrainingPlanCreateVM trainingPlanCreateVM)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await trainingPlanRepository.EditTrainingPlan(trainingPlanCreateVM);
					return RedirectToAction(nameof(Index), new { userId = trainingPlanCreateVM.UserId });
				}
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, "An error has occurred. Please try again later");
			}

			return View(trainingPlanCreateVM);
		}

		// POST: TrainingPlans/Delete
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = Roles.Administrator)]
		public async Task<IActionResult> DeleteConfirmed(int id, string userId)
		{
			await trainingPlanRepository.DeleteAsync(id);
			return RedirectToAction(nameof(Index), new { userId = userId });
		}

		// POST: TrainingPlans/ManageExercises/RemoveExercise
		[HttpPost, ActionName("RemoveExercise")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = Roles.Administrator)]
		public async Task<IActionResult> RemoveExercise(int id, int index)
		{
			await trainingPlanRepository.RemoveExerciseFromTrainingPlan(id, index);
			return RedirectToAction(nameof(ManageExercises), new { id = id });
		}
	}
}
