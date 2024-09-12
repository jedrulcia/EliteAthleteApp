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

namespace TrainingPlanApp.Web.Controllers
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
            var ingredientVM = await ingredientRepository.GetIngredientVM();
            return View(ingredientVM);
        }

        // GET: Ingredients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ingredients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IngredientVM ingredientVM)
        {
            if (ModelState.IsValid)
            {
                await ingredientRepository.CreateIngredient(ingredientVM);
                return RedirectToAction(nameof(Index));
            }
            return View(ingredientVM);
        }

        // GET: Ingredients/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            var ingredient = await ingredientRepository.GetAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            var ingredientVM = mapper.Map<IngredientVM>(ingredient);
            return View(ingredientVM);
        }

        // POST: Ingredients/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IngredientVM ingredientVM)
        {
            if (id != ingredientVM.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await ingredientRepository.EditIngredient(ingredientVM);
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
            return View(ingredientVM);
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
