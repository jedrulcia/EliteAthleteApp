using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainingPlanApp.Web.Contracts;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web
{
    public class IngredientsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IIngredientRepository ingredientRepository;
		private readonly IMapper mapper;

		public IngredientsController(ApplicationDbContext context, IIngredientRepository ingredientRepository, IMapper mapper)
        {
            _context = context;
            this.ingredientRepository = ingredientRepository;
			this.mapper = mapper;
		}

        // GET: Ingredients
        public async Task<IActionResult> Index()
        {
            var ingredientVM = mapper.Map<List<IngredientVM>>(await ingredientRepository.GetAllAsync());
            return View(ingredientVM);
        }

        // GET: Ingredients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IngredientVM ingredientVM)
        {
            if (ModelState.IsValid)
            {
                await ingredientRepository.CreateNewIngredient(ingredientVM);
                return RedirectToAction(nameof(Index));
            }
            return View(ingredientVM);
        }

        // GET: Ingredients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return View(ingredient);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Kcal,Proteins,Carbohydrates,Fats")] Ingredient ingredient)
        {
            if (id != ingredient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await ingredientRepository.GetAsync(ingredient.Id) == null)
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
            return View(ingredient);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await ingredientRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
