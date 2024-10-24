﻿using System;
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
using EliteAthleteApp.Constants;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Data;
using EliteAthleteApp.Models.Exercise;
using EliteAthleteApp.Models.Meal;

namespace EliteAthleteApp.Controllers
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

		// GET: Exercises/Create
		public async Task<IActionResult> Create()
		{
			return PartialView(await exerciseRepository.GetExerciseCreateVMAsync());
		}

		// POST: Exercises/Create
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

		// GET: Exercises/Edit
		public async Task<IActionResult> Edit(int id)
		{
			return PartialView(await exerciseRepository.GetExerciseEditVMAsync(id));
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

		// GET: Exercises/Details
		public async Task<IActionResult> Details(int id)
		{
			return PartialView(await exerciseRepository.GetExerciseDetailsVMAsync(id));
		}

		// GET: Exercises/Delete
		public async Task<IActionResult> Delete(int id)
		{
			return PartialView(await exerciseRepository.GetExerciseDeleteVMAsync(id));
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
