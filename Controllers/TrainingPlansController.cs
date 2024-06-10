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
		private readonly UserManager<User> userManager;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly IExerciseRepository exerciseRepository;
		private readonly ApplicationDbContext context;

        public TrainingPlansController(ApplicationDbContext context, 
            ITrainingPlanRepository trainingPlanRepository, 
            IMapper mapper, 
            UserManager<User> userManager,
            IHttpContextAccessor httpContextAccessor,
            IExerciseRepository exerciseRepository)
        {
            this.trainingPlanRepository = trainingPlanRepository;
            this.mapper = mapper;
			this.userManager = userManager;
			this.httpContextAccessor = httpContextAccessor;
			this.exerciseRepository = exerciseRepository;
			this.context = context;
        }

        // GET: TrainingPlans
        public async Task<IActionResult> Index(string? id)
		{
            var userId = id;
            if(userId == null)
            {
                var user = await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User);
                userId = user.Id;
            }

            var trainingPlansVM = mapper.Map<List<TrainingPlanVM>>(await trainingPlanRepository.GetUserTrainingPlans(userId));

            return View(trainingPlansVM);
        }

        // GET: TrainingPlans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var trainingPlan = await trainingPlanRepository.GetAsync(id);
            if (trainingPlan == null)
            {
                return NotFound();
            }
            trainingPlan.ExerciseFirst = await exerciseRepository.GetAsync(trainingPlan.ExerciseFirstId);
			trainingPlan.ExerciseSecond = await exerciseRepository.GetAsync(trainingPlan.ExerciseSecondId);
			trainingPlan.ExerciseThird = await exerciseRepository.GetAsync(trainingPlan.ExerciseThirdId);
			trainingPlan.ExerciseFourth = await exerciseRepository.GetAsync(trainingPlan.ExerciseFourthId);
			var trainingPlanVM = mapper.Map<TrainingPlanVM>(trainingPlan);
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
                Exercises = new SelectList(context.Exercises, "Id", "Name"),
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
                    var trainingPlan = mapper.Map<TrainingPlan>(model);
                    trainingPlan.IsActive = true;
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error has occurred. Please try again later");
            }

            model.Exercises = new SelectList(context.Exercises, "Id", "Name");
            return View(model);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Administrator)]
        public async Task<IActionResult> ChangeStatus(int id, bool status)
		{
			await trainingPlanRepository.ChangeTrainingPlanStatus(id, status);
			return RedirectToAction(nameof(Index));
		}


		// GET: TrainingPlans/Edit/5
		[Authorize(Roles = Roles.Administrator)]
        public async Task<IActionResult> Edit(int? id)
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
            trainingPlanCreateVM.Exercises = new SelectList(context.Exercises, "Id", "Name");
            trainingPlanCreateVM.IsActive = true;

            return View(trainingPlanCreateVM);
        }

        // POST: TrainingPlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Administrator)]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id,ExerciseFirstId,ExerciseSecondId,ExerciseThirdId,ExerciseFourthId,UserId")] TrainingPlan trainingPlan)
        {
            if (id != trainingPlan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(trainingPlan);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!context.TrainingPlans.Any(e => e.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExerciseFirstId"] = new SelectList(context.Exercises, "Id", "Id", trainingPlan.ExerciseFirstId);
            ViewData["ExerciseSecondId"] = new SelectList(context.Exercises, "Id", "Id", trainingPlan.ExerciseSecondId);
            ViewData["ExerciseThirdId"] = new SelectList(context.Exercises, "Id", "Id", trainingPlan.ExerciseThirdId);
            ViewData["ExerciseFourthId"] = new SelectList(context.Exercises, "Id", "Id", trainingPlan.ExerciseFourthId);
            return View(trainingPlan);
        }


        // POST: TrainingPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Administrator)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await trainingPlanRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
