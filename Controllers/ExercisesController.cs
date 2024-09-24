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
using TrainingPlanApp.Web.Models.Meal;

namespace TrainingPlanApp.Web.Controllers
{
    [Authorize(Roles = Roles.Administrator)]
	public class ExercisesController : Controller
	{
		private readonly IExerciseRepository exerciseRepository;
		private readonly IMapper mapper;

		public ExercisesController(IExerciseRepository exerciseRepository, IMapper mapper)
		{
			this.exerciseRepository = exerciseRepository;
			this.mapper = mapper;
		}

		// GET: Exercises
		public async Task<IActionResult> Index()
		{
			var exercisesVM = await exerciseRepository.GetExerciseIndexVM();
			return View(exercisesVM);
		}

		// GET: Exercises/Details
		public async Task<IActionResult> Details(int id)
		{
			var exerciseDetailsVM = await exerciseRepository.GetExerciseDetailsVM(id);
			return View(exerciseDetailsVM);
		}

		// GET: Exercises/Create
		public async Task<IActionResult> Create()
		{
			return View(await exerciseRepository.GetExerciseCreateVM());
		}

		// POST: Exercises/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ExerciseCreateVM exerciseCreateVM)
		{
			if (ModelState.IsValid)
            {
				await exerciseRepository.CreateExercise(exerciseCreateVM);
                return RedirectToAction(nameof(Index));
            }
			return View(exerciseCreateVM);
		}

		// GET: Exercises/Edit
		public async Task<IActionResult> Edit(int? id)
		{
			var exercise = await exerciseRepository.GetAsync(id);
			if (exercise == null)
			{
				return NotFound();
			}
			var exerciseVM = mapper.Map<ExerciseIndexVM>(exercise);
			return View(exerciseVM);
		}

		// POST: Exercises/Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, ExerciseCreateVM exerciseCreateVM)
		{
			if (id != exerciseCreateVM.Id)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				try
				{
					await exerciseRepository.EditExercise(exerciseCreateVM);
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!await exerciseRepository.Exists(exerciseCreateVM.Id))
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
			return View(exerciseCreateVM);
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
