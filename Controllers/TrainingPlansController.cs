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
using TrainingPlanApp.Web.Models.TrainingModule;
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
        private readonly ITrainingModuleRepository trainingModuleRepository;
        private readonly ApplicationDbContext context;

        public TrainingPlansController(ApplicationDbContext context,
			ITrainingPlanRepository trainingPlanRepository,
			IMapper mapper,
			IExerciseRepository exerciseRepository,
			UserManager<User> userManager,
			IHttpContextAccessor httpContextAccessor,
			ITrainingModuleRepository trainingModuleRepository)
		{
			this.mapper = mapper;
			this.exerciseRepository = exerciseRepository;
			this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
            this.trainingModuleRepository = trainingModuleRepository;
            this.trainingPlanRepository = trainingPlanRepository;
			this.context = context;
		}

		// GET: TrainingPlans
		public async Task<IActionResult> Index(int trainingModuleId)
        {
            List<int> trainingPlanIds = (await trainingModuleRepository.GetAsync(trainingModuleId)).TrainingPlanIds;
			var trainingPlanIndexVM = await trainingPlanRepository.GetTrainingPlanIndexVM(trainingPlanIds);
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

		// GET: TrainingPlans/ManageExercises
		[Authorize(Roles = Roles.Administrator)]
		public async Task<IActionResult> ManageExercises(int? id)
		{
			var trainingPlanManageExercisesVM = await trainingPlanRepository.GetTrainingPlanManageExercisesVM(id);
			return View(trainingPlanManageExercisesVM);
		}

		// POST: TrainingPlans/ManageExercises
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = Roles.Administrator)]
		public async Task<IActionResult> ManageExercises(TrainingPlanManageExercisesVM trainingPlanAddExercisesVM)
		{
			return View(await trainingPlanRepository.AddExerciseToTrainingPlan(trainingPlanAddExercisesVM));
		}

		// POST: TrainingPlans/Index/ChangeStatus
		public async Task<IActionResult> ChangeStatus(int id, bool status, int trainingModuleId)
		{
			await trainingPlanRepository.ChangeTrainingPlanCompletionStatus(id, status);
			return RedirectToAction(nameof(Index), new { trainingModuleId = trainingModuleId });
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
