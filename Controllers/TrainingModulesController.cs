using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Controllers
{
    public class TrainingModulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainingModulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TrainingModules
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrainingModules.ToListAsync());
        }

        // GET: TrainingModules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainingModules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Name")] TrainingModule trainingModule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainingModule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainingModule);
        }

        // GET: TrainingModules/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingModule = await _context.TrainingModules.FindAsync(id);
            if (trainingModule == null)
            {
                return NotFound();
            }
            return View(trainingModule);
        }

        // POST: TrainingModules/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Name")] TrainingModule trainingModule)
        {
            if (id != trainingModule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainingModule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (/*!TrainingModuleExists(trainingModule.Id)*/true)
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
            return View(trainingModule);
        }

        // POST: TrainingModules/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainingModule = await _context.TrainingModules.FindAsync(id);
            if (trainingModule != null)
            {
                _context.TrainingModules.Remove(trainingModule);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
