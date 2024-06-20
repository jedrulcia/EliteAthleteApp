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

        // GET : TrainingPlans
		public async Task<IActionResult> IndexAdmin()
		{
			var trainingPlansVM = await trainingPlanRepository.GetAllTrainingPlans();
			return View(trainingPlansVM);
		}

		// GET: TrainingPlans/Details
		public async Task<IActionResult> Details(int? id, bool redirectToAdmin)
        {
			var trainingPlan = await trainingPlanRepository.GetTrainingPlanDetails(id);
			if (trainingPlan == null)
            {
                return NotFound();
            }
			var trainingPlanVM = mapper.Map<TrainingPlanVM>(trainingPlan);
            trainingPlanVM.RedirectToAdmin = redirectToAdmin;
            return View(trainingPlanVM);
        }

        public async Task<IActionResult> ExerciseDetails(int? exerciseId, int? trainingPlanId)
        {
            var exercise = await exerciseRepository.GetAsync(exerciseId);
            if (exercise == null)
            {
                return NotFound();
            }
            var exerciseVM = mapper.Map<TrainingPlanExerciseVM>(exercise);
            exerciseVM.TrainingPlanId = trainingPlanId;
            return View(exerciseVM);
        }

        // GET: TrainingPlans/Create
        [Authorize(Roles = Roles.Administrator)]
        public IActionResult Create(string? userId)
        {
            var model = new TrainingPlanCreateVM
            {
                Exercises = new SelectList(context.Exercises.OrderBy(e => e.Name), "Id", "Name"),
                UserId = userId
            };
            return View(model);
        }

        // POST: TrainingPlans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            model.Exercises = new SelectList(context.Exercises, "Id", "Name");
            return View(model);
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
            var trainingPlan = await context.TrainingPlans.FindAsync(id);
            if (trainingPlan == null)
            {
                return NotFound();
            }
            var trainingPlanCreateVM = mapper.Map<TrainingPlanCreateVM>(trainingPlan);
            trainingPlanCreateVM.RedirectToAdmin = redirectToAdmin;
            trainingPlanCreateVM.Exercises = new SelectList(context.Exercises, "Id", "Name");
            return View(trainingPlanCreateVM);
        }

        // POST: TrainingPlans/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Administrator)]
        public async Task<IActionResult> Edit(TrainingPlanCreateVM model)
        {
			try
			{
				if (ModelState.IsValid)
				{
                    trainingPlanRepository.UpdateTrainingPlan(model);
					return RedirectToAction(nameof(Index), new { id = model.UserId });
				}
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, "An error has occurred. Please try again later");
			}

			model.Exercises = new SelectList(context.Exercises, "Id", "Name");
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
    }
}
