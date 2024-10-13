using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using TrainingPlanApp.Web.Constants;
using TrainingPlanApp.Web.Contracts;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models.Exercise;
using TrainingPlanApp.Web.Models.Meal;

namespace TrainingPlanApp.Web.Controllers
{
	[Authorize(Roles = Roles.Administrator + "," + Roles.Coach + "," + Roles.Full)]
	public class ExercisesController : Controller
	{
		private readonly IExerciseRepository exerciseRepository;
		private readonly IMapper mapper;
		private readonly ICompositeViewEngine viewEngine;
		private readonly ApplicationDbContext context;

		public ExercisesController(IExerciseRepository exerciseRepository, IMapper mapper, ICompositeViewEngine viewEngine, ApplicationDbContext context)
		{
			this.exerciseRepository = exerciseRepository;
			this.mapper = mapper;
			this.viewEngine = viewEngine;
			this.context = context;
		}

		// GET: Exercises
		public async Task<IActionResult> Index()
		{
			return View(await exerciseRepository.GetExerciseIndexVMAsync());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ExerciseCreateVM exerciseCreateVM)
		{
			if (ModelState.IsValid)
			{
				await exerciseRepository.CreateExerciseAsync(exerciseCreateVM);
				return RedirectToAction(nameof(Index));
			}

			TempData["ErrorMessage"] = $"Error while creating the exercise. Please try again.";
			return RedirectToAction(nameof(Index));
		}

		// POST: Exercises/Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(ExerciseCreateVM exerciseCreateVM)
		{
			if (ModelState.IsValid)
			{
				try
				{
					await exerciseRepository.EditExerciseAsync(exerciseCreateVM);
					return RedirectToAction(nameof(Index));
				}
				catch (DbUpdateConcurrencyException)
				{
					if (exerciseCreateVM.Id == null)
					{
						return NotFound();
					}
				}
			}

			TempData["ErrorMessage"] = $"Error while editing the exercise. Please try again.";
			return RedirectToAction(nameof(Index));
		}

		// POST: Exercises/Delete
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await exerciseRepository.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
