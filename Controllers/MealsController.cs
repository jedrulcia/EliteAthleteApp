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
using TrainingPlanApp.Web.Models.Meal;
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
			var mealsVM = await mealRepository.GetMealIndexVM();
			return View(mealsVM);
		}

		// POST: Meals/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(MealCreateVM mealCreateVM)
		{
			if (ModelState.IsValid)
			{
				await mealRepository.CreateMeal(mealCreateVM);
				return RedirectToAction(nameof(Index));
			}
			TempData["ErrorMessage"] = $"Error while creating the meal. Please try again.";
			return RedirectToAction(nameof(Index));
		}

		// POST: Meals/Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, MealCreateVM mealCreateVM)
		{
			if (ModelState.IsValid)
			{
				try
				{
					await mealRepository.EditMeal(mealCreateVM);
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!await mealRepository.Exists(id))
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
			TempData["ErrorMessage"] = $"Error while editing the meal. Please try again.";
			return RedirectToAction(nameof(Index));
		}

		// POST: Meals/Delete
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await mealRepository.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}

		// GET: Meals/ManageIngredients
		[Authorize(Roles = Roles.Administrator)]
		public async Task<IActionResult> ManageIngredients(int? id)
		{
			var mealManageIngredientsVM = await mealRepository.GetMealManageIngredientsVM(id);
			return View(mealManageIngredientsVM);
		}

		// POST: Meals/ManageIngredients/AddIngredient
		[HttpPost, ActionName("AddIngredient")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = Roles.Administrator)]
		public async Task<IActionResult> AddIngredient(MealManageIngredientsVM mealManageIngredientsVM)
		{
			await mealRepository.AddIngredientToMeal(mealManageIngredientsVM);
			return RedirectToAction(nameof(ManageIngredients), new { id = mealManageIngredientsVM.Id });
		}

		// POST: Meals/ManageIngredients/RemoveIngredient
		[HttpPost, ActionName("RemoveIngredient")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = Roles.Administrator)]
		public async Task<IActionResult> RemoveIngredient(int mealId, int index)
		{
			await mealRepository.RemoveIngredientFromMeal(mealId, index);
			return RedirectToAction(nameof(ManageIngredients), new { id = mealId });
		}
	}
}
