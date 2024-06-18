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
    [Authorize(Roles = Roles.Administrator)]
    public class MealsController : Controller
    {
        private readonly ApplicationDbContext _context;
		private readonly IMapper mapper;
		private readonly IMealRepository mealRepository;
        private readonly IIngredientRepository ingredientRepository;

        public MealsController(ApplicationDbContext context, IMapper mapper, IMealRepository mealRepository, IIngredientRepository ingredientRepository)
        {
            _context = context;
			this.mapper = mapper;
			this.mealRepository = mealRepository;
            this.ingredientRepository = ingredientRepository;
        }

        // GET: Meals
        public async Task<IActionResult> Index()
        {
            var mealsVM = mapper.Map<List<MealVM>>(await mealRepository.GetAllAsync());
            return View(mealsVM);
        }

        // GET: Meals/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            var mealVM = mapper.Map<MealVM>(mealRepository.GetAsync(id));
            if (mealVM == null)
            {
                return NotFound();
            }
            return View(mealVM);
        }

        // GET: Meals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Meals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        public async Task<IActionResult> CreateIngredient(MealCreateVM mealCreateVM)
        {
            await ingredientRepository.AddIngredient(mealCreateVM);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MealVM mealVM)
        {
            if (ModelState.IsValid)
            {
                var meal = mapper.Map<Meal>(mealVM);
                await mealRepository.AddAsync(meal);
                return RedirectToAction(nameof(Index));
            }
            return View(mealVM);
        }

        // GET: Meals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var meal = await mealRepository.GetAsync(id);
            if (meal == null)
            {
                return NotFound();
            }

            var mealVM = mapper.Map<MealVM>(meal);
            return View(mealVM);
        }

        // POST: Meals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MealVM mealVM)
		{
			if (ModelState.IsValid)
			{
				try
				{
                    var meal = mapper.Map<Meal>(mealVM);
                    await mealRepository.UpdateAsync(meal);
                }
				catch (DbUpdateConcurrencyException)
				{
					if (!await mealRepository.Exists(mealVM.Id))
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
			return View(mealVM);
		}


        // POST: Meals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await mealRepository.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}
    }
}
