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
using TrainingPlanApp.Web.Models.Ingredient;

namespace TrainingPlanApp.Web.Controllers
{
    [Authorize(Roles = Roles.Administrator)]
	public class IngredientsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IIngredientRepository ingredientRepository;
        private readonly IMapper mapper;

        public IngredientsController(ApplicationDbContext context, IIngredientRepository ingredientRepository, IMapper mapper)
        {
            this.context = context;
            this.ingredientRepository = ingredientRepository;
            this.mapper = mapper;
        }

        // GET: Ingredients
        public async Task<IActionResult> Index()
        {
            return View(await ingredientRepository.GetIngredientVM());
        }

        // GET: Ingredients/Create
        public async Task<IActionResult> Create()
		{
			IngredientCreateVM ingredientCreateVM = new IngredientCreateVM{ AvailableIngredientCategories = new SelectList(context.IngredientCategories.OrderBy(e => e.Name), "Id", "Name")	};
			return View(ingredientCreateVM);
        }

        // POST: Ingredients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IngredientCreateVM ingredientCreateVM)
        {
            if (ModelState.IsValid)
            {
                await ingredientRepository.CreateIngredient(ingredientCreateVM);
                return RedirectToAction(nameof(Index));
            }
            ingredientCreateVM.AvailableIngredientCategories = new SelectList(context.IngredientCategories.OrderBy(e => e.Name), "Id", "Name");
			return View(ingredientCreateVM);
        }

        // GET: Ingredients/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            var ingredient = await ingredientRepository.GetAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            var ingredientCreateVM = mapper.Map<IngredientCreateVM>(ingredient);
			ingredientCreateVM.AvailableIngredientCategories = new SelectList(context.IngredientCategories.OrderBy(e => e.Name), "Id", "Name");
			return View(ingredientCreateVM);
        }

        // POST: Ingredients/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IngredientCreateVM ingredientCreateVM)
        {
            if (id != ingredientCreateVM.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await ingredientRepository.EditIngredient(ingredientCreateVM);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await ingredientRepository.Exists(id))
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
			ingredientCreateVM.AvailableIngredientCategories = new SelectList(context.IngredientCategories.OrderBy(e => e.Name), "Id", "Name");
			return View(ingredientCreateVM);
        }

        // POST: Ingredients/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await ingredientRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
