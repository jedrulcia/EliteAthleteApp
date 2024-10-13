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
using PdfSharp.Pdf.Advanced;
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
			this.trainingPlanRepository = trainingPlanRepository;
			this.trainingModuleRepository = trainingModuleRepository;
			this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
			this.context = context;
		}

		// GET: TrainingPlans
		public async Task<IActionResult> Index(int trainingModuleId)
        {
            List<int> trainingPlanIds = (await trainingModuleRepository.GetAsync(trainingModuleId)).TrainingPlanIds;
			return View(await trainingPlanRepository.GetTrainingPlanIndexVMAsync(trainingPlanIds));
		}

		// GET: TrainingPlans/Details
		public async Task<IActionResult> Details(int? id)
		{
			var trainingPlan = await trainingPlanRepository.GetAsync(id);
			if (trainingPlan == null)
			{
				return NotFound();
			}
			return PartialView("Details", await trainingPlanRepository.GetTrainingPlanDetailsVMAsync(trainingPlan));
		}

		// GET: TrainingPlans/ManageExercises
		[Authorize(Roles = Roles.Administrator + "," + Roles.Coach + "," + Roles.Full)]

		public async Task<IActionResult> ManageExercises(int? id)
		{
			return View(await trainingPlanRepository.GetTrainingPlanManageExercisesVMAsync(id));
		}

		// POST: TrainingPlans/Index/ChangeStatus
		public async Task<IActionResult> ChangeStatus(int id, string raport, int trainingModuleId)
		{
			await trainingPlanRepository.CompleteTrainingPlanAsync(id, raport);
			return RedirectToAction(nameof(Index), new { trainingModuleId = trainingModuleId });
		}

		// POST: TrainingPlans/Index/PrintPDF
		public async Task<IActionResult> PrintPDF(int trainingModuleId)
		{
			List<int> trainingPlanIds = (await trainingModuleRepository.GetAsync(trainingModuleId)).TrainingPlanIds;
			byte[] pdf = await trainingPlanRepository.GetTrainingModulePDFAsync(trainingPlanIds);
			return File(pdf, "application/pdf", "PlanTreningowy.pdf");
		}

		// POST: TrainingPlans/ManageExercises/AddExercise
		[HttpPost, ActionName("AddExercise")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = Roles.Administrator + "," + Roles.Coach + "," + Roles.Full)]
		public async Task<IActionResult> AddExercise(TrainingPlanAddExerciseVM trainingPlanAddExerciseVM)
		{
			if (ModelState.IsValid)
			{
				await trainingPlanRepository.AddExerciseToTrainingPlanAsync(trainingPlanAddExerciseVM);
				return RedirectToAction(nameof(ManageExercises), new { id = trainingPlanAddExerciseVM.Id });
			}

			TempData["ErrorMessage"] = $"Error while adding the exercise. Index and Exercise fields are required. Please try again.";
			return RedirectToAction(nameof(ManageExercises), new { id = trainingPlanAddExerciseVM.Id });
		}

		// POST: TrainingPlans/ManageExercises/EditExercise
		[HttpPost, ActionName("EditExercise")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = Roles.Administrator + "," + Roles.Coach + "," + Roles.Full)]
		public async Task<IActionResult> EditExercises(TrainingPlanAddExerciseVM trainingPlanAddExerciseVM, int? index)
		{
			if (ModelState.IsValid)
			{
				await trainingPlanRepository.EditExerciseInTrainingPlanAsync(trainingPlanAddExerciseVM, index);
				return RedirectToAction(nameof(ManageExercises), new { id = trainingPlanAddExerciseVM.Id });
			}
			TempData["ErrorMessage"] = $"Error while adding the exercise. Index and Exercise fields are required. Please try again.";
			return RedirectToAction(nameof(ManageExercises), new { id = trainingPlanAddExerciseVM.Id });
		}

		// POST: TrainingPlans/ManageExercises/RemoveExercise
		[HttpPost, ActionName("RemoveExercise")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = Roles.Administrator + "," + Roles.Coach + "," + Roles.Full)]
		public async Task<IActionResult> RemoveExercise(int trainingPlanId, int index)
		{
			await trainingPlanRepository.RemoveExerciseFromTrainingPlanAsync(trainingPlanId, index);
			return RedirectToAction(nameof(ManageExercises), new { id = trainingPlanId });
		}

		// POST: TrainingPlans/ManageExercises/CopyTrainingPlan
		[HttpPost, ActionName("CopyTrainingPlan")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = Roles.Administrator + "," + Roles.Coach + "," + Roles.Full)]
		public async Task<IActionResult> CopyTrainingPlan(int copyFromId, int copyToId, int trainingModuleId)
		{
			await trainingPlanRepository.CopyTrainingPlanAsync(copyFromId, copyToId);
			return RedirectToAction(nameof(Index), new { trainingModuleId = trainingModuleId });
		}
	}
}
