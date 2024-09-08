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
        private readonly ApplicationDbContext context;
		private readonly IMapper mapper;
		private readonly IMealRepository mealRepository;
        private readonly IIngredientRepository ingredientRepository;

        public MealsController(ApplicationDbContext context, IMapper mapper, IMealRepository mealRepository, IIngredientRepository ingredientRepository)
        {
            this.context = context;
			this.mapper = mapper;
			this.mealRepository = mealRepository;
            this.ingredientRepository = ingredientRepository;
        }

        // GET: Meals
        public async Task<IActionResult> Index()
        {
            var mealsVM = mapper.Map<List<MealVM>>(await mealRepository.GetAllAsync());
            mealsVM = await mealRepository.GetMacrosOfTheMeals(mealsVM);
            return View(mealsVM);
        }

        // GET: Meals/Details
        public async Task<IActionResult> Details(int? id)
        {
            var meal = await mealRepository.GetAsync(id.Value);
            if (meal == null)
            {
                return NotFound();
            }
            var mealVM = mapper.Map<MealVM>(meal);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MealCreateVM mealCreateVM)
        {
            if (ModelState.IsValid)
            {
                await mealRepository.CreateNewMeal(mealCreateVM);
                return RedirectToAction(nameof(Index));
            }
            return View(mealCreateVM);
        }

/*        public async Task<IActionResult> AddIngredients(int? id)
        {
            var meal = await mealRepository.GetAsync(id);
            if (meal == null)
            {
                return NotFound();
            }
            var mealCreateVM = ingredientRepository.CreateIngredientAddingModel(meal);
            return View(mealCreateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddIngredients(MealCreateVM mealCreateVM)
        {
            if (ModelState.IsValid)
            {
                return View(await ingredientRepository.AddIngredientSequence(mealCreateVM));
            }
            return View(mealCreateVM);
        }*/

        // GET: Meals/Edit
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

        // POST: Meals/Edit
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
                    await mealRepository.EditMeal(mealVM);
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

        // POST: Meals/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await mealRepository.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
        }        

/*        // POST: Meals/AddIngredients/Delete
        [HttpPost, ActionName("DeleteIngredient")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteIngredient(int ingredientId, int mealId)
        {
            await ingredientRepository.DeleteAsync(ingredientId);
            return RedirectToAction(nameof(AddIngredients), new { id = mealId});
        }*/
    }
}
