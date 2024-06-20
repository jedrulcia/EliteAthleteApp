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
            return View(mealsVM);
        }

        // GET: Meals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
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
                var meal = mapper.Map<Meal>(mealCreateVM);
                await mealRepository.AddAsync(meal);
                return RedirectToAction(nameof(Index));
            }
            return View(mealCreateVM);
        }

        public async Task<IActionResult> AddIngredients(int? id)
        {
            var meal = await mealRepository.GetAsync(id);
            if (meal == null)
            {
                return NotFound();
            }
            var mealCreateVM = mapper.Map<MealCreateVM>(meal);
            var ingredientVM = mapper.Map<List<IngredientVM>>(context.Ingredients.Where(e => e.MealId == mealCreateVM.Id));
            mealCreateVM.Ingredients = new List<IngredientVM>(ingredientVM);
            return View(mealCreateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddIngredients(MealCreateVM mealCreateVM)
        {
            if (ModelState.IsValid)
            {
                var ingredient = mapper.Map<Ingredient>(mealCreateVM);
                await ingredientRepository.AddAsync(ingredient);
                var ingredientVM = mapper.Map<List<IngredientVM>>(context.Ingredients.Where(e => e.MealId == mealCreateVM.Id));
                mealCreateVM.Ingredients = new List<IngredientVM>(ingredientVM);
                mealCreateVM.IngredientName = null;
                mealCreateVM.IngredientServingSize = null;
                return View(mealCreateVM);
            }
            return View(mealCreateVM);
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

        // POST: Meals/Delete/5      
        [HttpPost, ActionName("DeleteIngredient")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteIngredient(int ingredientId, int mealId)
        {
            await ingredientRepository.DeleteAsync(ingredientId);
            return RedirectToAction(nameof(AddIngredients), new { id = mealId});
        }
    }
}
