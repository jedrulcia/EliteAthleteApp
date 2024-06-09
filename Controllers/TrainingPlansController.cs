using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        private readonly ApplicationDbContext context;

        public TrainingPlansController(ApplicationDbContext context, ITrainingPlanRepository trainingPlanRepository, IMapper mapper)
        {
            this.trainingPlanRepository = trainingPlanRepository;
            this.mapper = mapper;
            this.context = context;
        }

        // GET: TrainingPlans
        public async Task<IActionResult> Index()
        {
            var trainingPlansVM = mapper.Map<List<TrainingPlanVM>>(await trainingPlanRepository.GetAllAsync());
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
            var trainingPlanVM = mapper.Map<TrainingPlanVM>(trainingPlan);
            return View(trainingPlanVM);
        }

        // GET: TrainingPlans/Create
        public IActionResult Create()
        {
            var model = new TrainingPlanCreateVM
            {
                Exercises = new SelectList(context.Exercises, "Id", "Name"),
            };
            return View(model);
        }

        // POST: TrainingPlans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrainingPlanCreateVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var trainingPlan = mapper.Map<TrainingPlan>(model);
                    await trainingPlanRepository.AddAsync(trainingPlan);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error has occurred. Please try again later");
            }

            return View(model);
        }

        // GET: TrainingPlans/Edit/5
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
            ViewData["ExerciseFirstId"] = new SelectList(context.Exercises, "Id", "Id", trainingPlan.ExerciseFirstId);
            ViewData["ExerciseSecondId"] = new SelectList(context.Exercises, "Id", "Id", trainingPlan.ExerciseSecondId);
            ViewData["ExerciseThirdId"] = new SelectList(context.Exercises, "Id", "Id", trainingPlan.ExerciseThirdId);
            ViewData["ExerciseFourthId"] = new SelectList(context.Exercises, "Id", "Id", trainingPlan.ExerciseFourthId);
            return View(trainingPlan);
        }

        // POST: TrainingPlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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
                    if (!TrainingPlanExists(trainingPlan.Id))
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
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = Roles.Administrator)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await trainingPlanRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingPlanExists(int id)
        {
            return context.TrainingPlans.Any(e => e.Id == id);
        }
    }
}
