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
using TrainingPlanApp.Web.Models.Exercise;
using TrainingPlanApp.Web.Models.Ingredient;
using TrainingPlanApp.Web.Repositories;

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
            return View(await ingredientRepository.GetIngredientIndexVM());
        }

        // POST: Ingredients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IngredientCreateVM ingredientCreateVM, int? id)
        {
            if (ModelState.IsValid)
            {
                await ingredientRepository.CreateIngredient(ingredientCreateVM);
				return HandleCreateRedirect(ingredientCreateVM.Redirect, id);
			}

			TempData["ErrorMessage"] = $"Error while creating the ingredient. Please try again.";
			return HandleCreateRedirect(ingredientCreateVM.Redirect, id);
		}

        // POST: Ingredients/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IngredientCreateVM ingredientCreateVM)
        {
			if (ModelState.IsValid)
			{
				try
				{
					await ingredientRepository.EditIngredient(ingredientCreateVM);
					return RedirectToAction(nameof(Index));
				}
				catch (DbUpdateConcurrencyException)
				{
					if (ingredientCreateVM.Id == null)
					{
						return NotFound();
					}
				}
			}
			TempData["ErrorMessage"] = $"Error while editing the ingredient. Please try again.";
			return RedirectToAction(nameof(Index));
		}

        // POST: Ingredients/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await ingredientRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

		// USED INSIDE OF CLASS

		// HANDLES REDIRECTING FROM CREATE INGREDIENT
		private IActionResult HandleCreateRedirect(string redirect, int? id)
		{
			if (redirect == "Meals")
			{
				return RedirectToAction("ManageIngredients", "Meals", new { id = id });
			}
			else if (redirect == "Diets")
			{
				return RedirectToAction("Index", "Diets", new { id = id });
			}
			else
			{
				return RedirectToAction(nameof(Index));
			}
		}

	}
}
