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
using TrainingPlanApp.Web.Repositories;

namespace TrainingPlanApp.Web.Controllers
{
    public class TrainingPlansController : Controller
    {
        private readonly ITrainingPlanRepository trainingPlanRepository;
        private readonly IMapper mapper;
        private readonly IExerciseRepository exerciseRepository;
        private readonly ApplicationDbContext context;

        public TrainingPlansController(ApplicationDbContext context,
            ITrainingPlanRepository trainingPlanRepository,
            IMapper mapper,
            IExerciseRepository exerciseRepository)
        {
            this.mapper = mapper;
            this.exerciseRepository = exerciseRepository;
            this.trainingPlanRepository = trainingPlanRepository;
            this.context = context;
        }

        // GET: TrainingPlans
        public async Task<IActionResult> Index(string? id)
        {
            var trainingPlansVM = await trainingPlanRepository.GetUserTrainingPlans(id);
            return View(trainingPlansVM);
        }

        // GET : TrainingPlansAdmin
        public async Task<IActionResult> IndexAdmin()
        {
            var trainingPlansVM = await trainingPlanRepository.GetTrainingPlanIndexAdminVM();
            return View(trainingPlansVM);
		}

		// GET: TrainingPlans/ActiveTrainingPlans
		public async Task<IActionResult> ActiveTrainingPlans(string? id)
		{
			var trainingPlansActiveVM = await trainingPlanRepository.GetUserActiveTrainingPlans(id);
			return View(trainingPlansActiveVM);
		}

		// GET: TrainingPlans/ExerciseDetails
		public async Task<IActionResult> ExerciseDetails(int? id, string? userId)
		{
            var trainingPlanExerciseDetailsVM = await trainingPlanRepository.GetTrainingPlanExerciseDetailsVM(id, userId);
			return View(trainingPlanExerciseDetailsVM);
		}

		// GET: TrainingPlans/Details
		public async Task<IActionResult> Details(int? id, bool redirectToAdmin)
		{
			var trainingPlan = await trainingPlanRepository.GetAsync(id);
			if (trainingPlan == null)
			{
				return NotFound();
			}

			var trainingPlanDetailsVM = await trainingPlanRepository.GetTrainingPlanDetailsVM(trainingPlan, redirectToAdmin);
			return View(trainingPlanDetailsVM);
		}

		// GET: TrainingPlans/Create
		[Authorize(Roles = Roles.Administrator)]
        public IActionResult Create(string? userId)
        {
            var model = new TrainingPlanCreateVM
            {
                UserId = userId
            };
            return View(model);
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
                    return RedirectToAction(nameof(Index), new { id = model.UserId });
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
        public async Task<IActionResult> ManageExercises(int? id, bool redirectToAdmin)
        {
            var trainingPlanManageExercisesVM = await trainingPlanRepository.GetTrainingPlanManageExercisesVM(id, redirectToAdmin);
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
            if (userId == null)
            {
                return RedirectToAction(nameof(IndexAdmin));
            }
            return RedirectToAction(nameof(Index), new { id = userId });
        }

        // GET: TrainingPlans/Edit
        [Authorize(Roles = Roles.Administrator)]
        public async Task<IActionResult> Edit(int? id, bool redirectToAdmin)
        {
            if (id == null)
            {
                return NotFound();
            }
            var trainingPlanCreateVM = mapper.Map<TrainingPlanCreateVM>(await trainingPlanRepository.GetAsync(id));
            trainingPlanCreateVM.RedirectToAdmin = redirectToAdmin;
            return View(trainingPlanCreateVM);
        }

        // POST: TrainingPlans/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Administrator)]
        public async Task<IActionResult> Edit(TrainingPlanCreateVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await trainingPlanRepository.EditTrainingPlan(model);
                    if (model.RedirectToAdmin)
					{
						return RedirectToAction(nameof(IndexAdmin));
					}
                    else
					{
						return RedirectToAction(nameof(Index), new { id = model.UserId });
					}
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error has occurred. Please try again later");
            }

            return View(model);
        }

		// POST: TrainingPlans/Delete
		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Administrator)]
        public async Task<IActionResult> DeleteConfirmed(int id, string userId)
        {
            await trainingPlanRepository.DeleteAsync(id);
            if (userId == null)
            {
                return RedirectToAction(nameof(IndexAdmin));
            }
            return RedirectToAction(nameof(Index), new { id = userId });
		}

		// POST: TrainingPlans/ManageExercises/RemoveExercise
		[HttpPost, ActionName("RemoveExercise")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = Roles.Administrator)]
		public async Task<IActionResult> RemoveExercise(int trainingPlanId, int index)
		{
			await trainingPlanRepository.RemoveExerciseFromTrainingPlan(trainingPlanId, index);
			return RedirectToAction(nameof(ManageExercises), new { id = trainingPlanId });
		}
	}
}
