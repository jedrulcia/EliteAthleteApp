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
using EliteAthleteApp.Constants;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models;
using EliteAthleteApp.Models.TrainingModule;
using EliteAthleteApp.Models.TrainingPlan;
using EliteAthleteApp.Repositories;

namespace EliteAthleteApp.Controllers
{
    public class TrainingPlansController : Controller
	{
		private readonly ITrainingPlanRepository trainingPlanRepository;
        private readonly ITrainingModuleRepository trainingModuleRepository;
		private readonly IPdfService pdfService;

        public TrainingPlansController(ITrainingPlanRepository trainingPlanRepository,
			ITrainingModuleRepository trainingModuleRepository,
			IPdfService pdfService)
		{
			this.trainingPlanRepository = trainingPlanRepository;
			this.trainingModuleRepository = trainingModuleRepository;
			this.pdfService = pdfService;
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

		public async Task<IActionResult> ChangeStatus(int trainingPlanId)
		{
			return PartialView("ChangeStatus", await trainingPlanRepository.GetTrainingPlanChangeStatusVMAsync(trainingPlanId));
		}

		// POST: TrainingPlans/ChangeStatus
		[HttpPost, ActionName("ChangeStatus")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ChangeStatus(int id, string raport, int trainingModuleId)
		{
			await trainingPlanRepository.CompleteTrainingPlanAsync(id, raport);
			return RedirectToAction(nameof(Index), new { trainingModuleId = trainingModuleId });
		}

		// POST: TrainingPlans/PrintPDF
		public async Task<IActionResult> PrintPDF(int trainingModuleId)
		{
			byte[] pdf = await pdfService.GetTrainingModulePDFAsync(trainingModuleId);
			return File(pdf, "application/pdf", "PlanTreningowy.pdf");
		}

		// GET: TrainingPlans/ManageExercises/AddExercise
		public async Task<IActionResult> AddExercise(int trainingPlanId, string coachId)
        {
            return PartialView("AddExercise", await trainingPlanRepository.GetTrainingPlanAddExerciseVMAsync(trainingPlanId, coachId));
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
				return RedirectToAction(nameof(ManageExercises), new { id = trainingPlanAddExerciseVM.TrainingPlanId });
			}

			TempData["ErrorMessage"] = $"Error while adding the exercise. Index and Exercise fields are required. Please try again.";
			return RedirectToAction(nameof(ManageExercises), new { id = trainingPlanAddExerciseVM.TrainingPlanId });
		}

		// GET: TrainingPlans/ManageExercises/EditExercise
		public async Task<IActionResult> EditExercise(int trainingPlanId, string coachId, int trainingPlanExerciseDetailId)
		{
			return PartialView("EditExercise", await trainingPlanRepository.GetTrainingPlanEditExerciseVMAsync(trainingPlanId, coachId, trainingPlanExerciseDetailId));
		}

		// POST: TrainingPlans/ManageExercises/EditExercise
		[HttpPost, ActionName("EditExercise")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = Roles.Administrator + "," + Roles.Coach + "," + Roles.Full)]
		public async Task<IActionResult> EditExercise(TrainingPlanAddExerciseVM trainingPlanAddExerciseVM)
		{
			if (ModelState.IsValid)
			{
				await trainingPlanRepository.EditExerciseInTrainingPlanAsync(trainingPlanAddExerciseVM);
				return RedirectToAction(nameof(ManageExercises), new { id = trainingPlanAddExerciseVM.TrainingPlanId });
			}
			TempData["ErrorMessage"] = $"Error while adding the exercise. Index and Exercise fields are required. Please try again.";
			return RedirectToAction(nameof(ManageExercises), new { id = trainingPlanAddExerciseVM.TrainingPlanId });
		}

		// GET: TrainingPlans/ManageExercises/RemoveExercise
		public async Task<IActionResult> RemoveExercise(int trainingPlanId, int trainingPlanExerciseDetailId, string name)
		{
			
			return PartialView("RemoveExercise", await trainingPlanRepository.GetTrainingPlanRemoveExerciseVM(trainingPlanId, trainingPlanExerciseDetailId, name));
		}

		// POST: TrainingPlans/ManageExercises/RemoveExercise
		[HttpPost, ActionName("RemoveExercise")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = Roles.Administrator + "," + Roles.Coach + "," + Roles.Full)]
		public async Task<IActionResult> RemoveExercise(TrainingPlanRemoveExerciseVM trainingPlanRemoveExerciseVM)
		{
			await trainingPlanRepository.RemoveExerciseFromTrainingPlanAsync(trainingPlanRemoveExerciseVM);
			return RedirectToAction(nameof(ManageExercises), new { id = trainingPlanRemoveExerciseVM.TrainingPlanId });
		}

		public async Task<IActionResult> Copy(int copyFromId, int trainingModuleId)
		{
			List<int> trainingPlanIds = (await trainingModuleRepository.GetAsync(trainingModuleId)).TrainingPlanIds;
			return PartialView("Copy", await trainingPlanRepository.GetTrainingPlanCopyVMAsync(copyFromId, trainingPlanIds));
		}

		// POST: TrainingPlans/ManageExercises/CopyTrainingPlan
		[HttpPost, ActionName("Copy")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = Roles.Administrator + "," + Roles.Coach + "," + Roles.Full)]
		public async Task<IActionResult> Copy(int copyFromId, int copyToId, int trainingModuleId)
		{
			await trainingPlanRepository.CopyTrainingPlanAsync(copyFromId, copyToId);
			return RedirectToAction(nameof(Index), new { trainingModuleId = trainingModuleId });
		}
	}
}
