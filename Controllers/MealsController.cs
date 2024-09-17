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
			var mealsVM = await mealRepository.GetMealIndexVM();
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
			var mealDetailsVM = await mealRepository.GetMealDetailsVM(meal);
			return View(mealDetailsVM);
		}

		// GET: Meals/Create
		public IActionResult Create()
		{
			return View();
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
			return View(mealCreateVM);
		}

		// GET: Meals/ManageIngredients
		[Authorize(Roles = Roles.Administrator)]
		public async Task<IActionResult> ManageIngredients(int? id, bool redirectToAdmin)
		{
			var mealManageIngredientsVM = await mealRepository.GetMealManageIngredientsVM(id, redirectToAdmin);
			return View(mealManageIngredientsVM);
		}

		// POST: Meals/ManageIngredients
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = Roles.Administrator)]
		public async Task<IActionResult> ManageIngredients(MealManageIngredientsVM mealManageIngredientsVM)
		{
			return View(await mealRepository.AddIngredientToMeal(mealManageIngredientsVM));
		}

		// GET: Meals/Edit
		public async Task<IActionResult> Edit(int? id)
		{
			var meal = await mealRepository.GetAsync(id);
			if (meal == null)
			{
				return NotFound();
			}
			var mealCreateVM = mapper.Map<MealCreateVM>(meal);
			return View(mealCreateVM);
		}

		// POST: Meals/Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, MealCreateVM mealCreateVM)
		{
			if (id != mealCreateVM.Id)
			{
				return NotFound();
			}
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
			return View(mealCreateVM);
		}

		// POST: Meals/Delete
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await mealRepository.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
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
