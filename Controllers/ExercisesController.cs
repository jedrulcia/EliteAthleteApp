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
			var exercisesVM = mapper.Map<List<ExerciseVM>>(await exerciseRepository.GetAllAsync());
			return View(exercisesVM);
		}

		// GET: Exercises/Details
		public async Task<IActionResult> Details(int? id)
		{
			var exercise = await exerciseRepository.GetAsync(id);
			if (exercise == null)
			{
				return NotFound();
			}
			var exerciseVM = mapper.Map<ExerciseVM>(exercise);
			return View(exerciseVM);
		}

		// GET: Exercises/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Exercises/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ExerciseVM exerciseVM)
		{
			if (ModelState.IsValid)
            {
				await exerciseRepository.CreateNewExercise(exerciseVM);
                return RedirectToAction(nameof(Index));
            }
			return View(exerciseVM);
		}



		// GET: Exercises/Edit
		public async Task<IActionResult> Edit(int? id)
		{
			var exercise = await exerciseRepository.GetAsync(id);
			if (exercise == null)
			{
				return NotFound();
			}
			var exerciseVM = mapper.Map<ExerciseVM>(exercise);
			return View(exerciseVM);
		}

		// POST: Exercises/Edit
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, ExerciseVM exerciseVM)
		{
			if (id != exerciseVM.Id)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				try
				{
					await exerciseRepository.EditExercise(exerciseVM);
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!await exerciseRepository.Exists(exerciseVM.Id))
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
			return View(exerciseVM);
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
