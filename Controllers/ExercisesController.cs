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
	[Authorize(Roles = Roles.Administrator)]
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
			return View(await exerciseRepository.GetExerciseIndexVM());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ExerciseCreateVM exerciseCreateVM)
		{
			if (ModelState.IsValid)
			{
				await exerciseRepository.CreateExercise(exerciseCreateVM);

				// Zwróć sukces w formacie JSON
				return Json(new { success = true });
			}

			// Jeśli ModelState jest niepoprawny, pobierz kategorie ponownie
			exerciseCreateVM.AvailableCategories = (await exerciseRepository.GetExerciseCreateVM()).AvailableCategories;

			// W przypadku błędów walidacyjnych, wygeneruj ponownie HTML formularza i przekaż go jako odpowiedź JSON
			var html = await this.RenderViewAsync("PartialViewWithCreateForm", exerciseCreateVM, true); // Użyj tutaj np. PartialView do odświeżania formularza
			return Json(new { success = false, html });
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
                    await exerciseRepository.EditExercise(exerciseCreateVM);

                    // Zwróć sukces w formacie JSON
                    return Json(new { success = true });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (exerciseCreateVM.Id == null)
                    {
                        return NotFound();
                    }
                    // Możesz dodać logikę obsługi błędów, jeśli potrzebujesz
                }
            }

            // Jeśli ModelState jest niepoprawny, pobierz kategorie ponownie
            exerciseCreateVM.AvailableCategories = (await exerciseRepository.GetExerciseCreateVM()).AvailableCategories;

            // W przypadku błędów walidacyjnych, wygeneruj ponownie HTML formularza i przekaż go jako odpowiedź JSON
            var html = await this.RenderViewAsync("PartialViewWithEditForm", exerciseCreateVM, true); // Użyj tutaj np. PartialView do odświeżania formularza
            return Json(new { success = false, html });
        }

		// POST: Exercises/Delete
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await exerciseRepository.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}



		public async Task<string> RenderViewAsync(string viewName, object model, bool partial = false)
		{
			if (string.IsNullOrEmpty(viewName))
				viewName = ControllerContext.ActionDescriptor.ActionName;
			ViewData.Model = model;

			using (var writer = new StringWriter())
			{
				var viewResult = viewEngine.FindView(ControllerContext, viewName, !partial);

				if (viewResult.View == null)
					throw new ArgumentNullException($"{viewName} does not match any available view");

				var viewContext = new ViewContext(
					ControllerContext,
					viewResult.View,
					ViewData,
					TempData,
					writer,
					new HtmlHelperOptions()
				);

				await viewResult.View.RenderAsync(viewContext);
				return writer.GetStringBuilder().ToString();
			}
		}
	}
}
