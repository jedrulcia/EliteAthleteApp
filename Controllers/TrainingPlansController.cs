using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Models.TrainingPlan;

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
			return View(await trainingPlanRepository.GetTrainingPlanIndexVMAsync(trainingPlanIds, trainingModuleId));
		}

		// GET: TrainingPlans/Details
		public async Task<IActionResult> Details(int trainingPlanId)
		{
			return View(await trainingPlanRepository.GetTrainingPlanDetailsVMAsync(trainingPlanId));
		}

		public async Task<IActionResult> ChangeStatus(int trainingPlanId)
		{
			return PartialView(await trainingPlanRepository.GetTrainingPlanChangeStatusVMAsync(trainingPlanId));
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

		// GET: TrainingPlans/Details/AddExercise
		public async Task<IActionResult> AddExercise(int trainingPlanId, string coachId)
        {
            return PartialView(await trainingPlanRepository.GetTrainingPlanAddExerciseVMAsync(trainingPlanId, coachId));
        }

		// POST: TrainingPlans/Details/AddExercise
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddExercise(TrainingPlanAddExerciseVM trainingPlanAddExerciseVM)
		{
			if (ModelState.IsValid)
			{
				await trainingPlanRepository.AddExerciseToTrainingPlanAsync(trainingPlanAddExerciseVM);
				return RedirectToAction(nameof(Details), new { trainingPlanId = trainingPlanAddExerciseVM.TrainingPlanId });
			}
			TempData["ErrorMessage"] = ModelState.Values
				.SelectMany(v => v.Errors)
				.Select(e => e.ErrorMessage)
				.FirstOrDefault() ?? "Error while adding Exercise. Please try again.";
			return RedirectToAction(nameof(Details), new { trainingPlanId = trainingPlanAddExerciseVM.TrainingPlanId });
		}

		// GET: TrainingPlans/Details/EditExercise
		public async Task<IActionResult> EditExercise(int trainingPlanId, string coachId, int trainingPlanExerciseDetailId)
		{
			return PartialView("EditExercise", await trainingPlanRepository.GetTrainingPlanEditExerciseVMAsync(trainingPlanId, coachId, trainingPlanExerciseDetailId));
		}

		// POST: TrainingPlans/ManageExercises/EditExercise
		[HttpPost, ActionName("EditExercise")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditExercise(TrainingPlanAddExerciseVM trainingPlanAddExerciseVM)
		{
			if (ModelState.IsValid)
			{
				await trainingPlanRepository.EditExerciseInTrainingPlanAsync(trainingPlanAddExerciseVM);
				return RedirectToAction(nameof(Details), new { trainingPlanId = trainingPlanAddExerciseVM.TrainingPlanId });
			}
			TempData["ErrorMessage"] = ModelState.Values
				.SelectMany(v => v.Errors)
				.Select(e => e.ErrorMessage)
				.FirstOrDefault() ?? "Error while editing Exercise. Please try again.";
			return RedirectToAction(nameof(Details), new { trainingPlanId = trainingPlanAddExerciseVM.TrainingPlanId });
		}

		// GET: TrainingPlans/Details/RemoveExercise
		public async Task<IActionResult> RemoveExercise(int trainingPlanId, int trainingPlanExerciseDetailId, string name)
		{
			
			return PartialView("RemoveExercise", await trainingPlanRepository.GetTrainingPlanRemoveExerciseVM(trainingPlanId, trainingPlanExerciseDetailId, name));
		}

		// POST: TrainingPlans/Details/RemoveExercise
		[HttpPost, ActionName("RemoveExercise")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> RemoveExercise(TrainingPlanRemoveExerciseVM trainingPlanRemoveExerciseVM)
		{
			await trainingPlanRepository.RemoveExerciseFromTrainingPlanAsync(trainingPlanRemoveExerciseVM);
			return RedirectToAction(nameof(Details), new { trainingPlanId = trainingPlanRemoveExerciseVM.TrainingPlanId });
		}

		public async Task<IActionResult> Copy(int copyFromId, int trainingModuleId)
		{
			List<int> trainingPlanIds = (await trainingModuleRepository.GetAsync(trainingModuleId)).TrainingPlanIds;
			return PartialView("Copy", await trainingPlanRepository.GetTrainingPlanCopyVMAsync(copyFromId, trainingPlanIds, trainingModuleId));
		}

		// POST: TrainingPlans/Details/CopyTrainingPlan
		[HttpPost, ActionName("Copy")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Copy(int copyFromId, int copyToId, int trainingModuleId)
		{
			await trainingPlanRepository.CopyTrainingPlanAsync(copyFromId, copyToId);
			return RedirectToAction(nameof(Index), new { trainingModuleId = trainingModuleId });
		}
	}
}
