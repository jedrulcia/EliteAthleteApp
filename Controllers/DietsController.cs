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
    public class DietsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DietsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Diets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Diets.Include(d => d.Breakfast).Include(d => d.Dinner).Include(d => d.Lunch).Include(d => d.SecondBreakfast).Include(d => d.Snack);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Diets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diet = await _context.Diets
                .Include(d => d.Breakfast)
                .Include(d => d.Dinner)
                .Include(d => d.Lunch)
                .Include(d => d.SecondBreakfast)
                .Include(d => d.Snack)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diet == null)
            {
                return NotFound();
            }

            return View(diet);
        }

        // GET: Diets/Create
        public IActionResult Create()
        {
            ViewData["BreakfastId"] = new SelectList(_context.Meals, "Id", "Id");
            ViewData["DinnerId"] = new SelectList(_context.Meals, "Id", "Id");
            ViewData["LunchId"] = new SelectList(_context.Meals, "Id", "Id");
            ViewData["SecondBreakfastId"] = new SelectList(_context.Meals, "Id", "Id");
            ViewData["SnackId"] = new SelectList(_context.Meals, "Id", "Id");
            return View();
        }

        // POST: Diets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id,UserId,IsActive,Description,StartDate,BreakfastId,SecondBreakfastId,LunchId,SnackId,DinnerId")] Diet diet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BreakfastId"] = new SelectList(_context.Meals, "Id", "Id", diet.BreakfastId);
            ViewData["DinnerId"] = new SelectList(_context.Meals, "Id", "Id", diet.DinnerId);
            ViewData["LunchId"] = new SelectList(_context.Meals, "Id", "Id", diet.LunchId);
            ViewData["SecondBreakfastId"] = new SelectList(_context.Meals, "Id", "Id", diet.SecondBreakfastId);
            ViewData["SnackId"] = new SelectList(_context.Meals, "Id", "Id", diet.SnackId);
            return View(diet);
        }

        // GET: Diets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diet = await _context.Diets.FindAsync(id);
            if (diet == null)
            {
                return NotFound();
            }
            ViewData["BreakfastId"] = new SelectList(_context.Meals, "Id", "Id", diet.BreakfastId);
            ViewData["DinnerId"] = new SelectList(_context.Meals, "Id", "Id", diet.DinnerId);
            ViewData["LunchId"] = new SelectList(_context.Meals, "Id", "Id", diet.LunchId);
            ViewData["SecondBreakfastId"] = new SelectList(_context.Meals, "Id", "Id", diet.SecondBreakfastId);
            ViewData["SnackId"] = new SelectList(_context.Meals, "Id", "Id", diet.SnackId);
            return View(diet);
        }

        // POST: Diets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id,UserId,IsActive,Description,StartDate,BreakfastId,SecondBreakfastId,LunchId,SnackId,DinnerId")] Diet diet)
        {
            if (id != diet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DietExists(diet.Id))
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
            ViewData["BreakfastId"] = new SelectList(_context.Meals, "Id", "Id", diet.BreakfastId);
            ViewData["DinnerId"] = new SelectList(_context.Meals, "Id", "Id", diet.DinnerId);
            ViewData["LunchId"] = new SelectList(_context.Meals, "Id", "Id", diet.LunchId);
            ViewData["SecondBreakfastId"] = new SelectList(_context.Meals, "Id", "Id", diet.SecondBreakfastId);
            ViewData["SnackId"] = new SelectList(_context.Meals, "Id", "Id", diet.SnackId);
            return View(diet);
        }

        // GET: Diets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diet = await _context.Diets
                .Include(d => d.Breakfast)
                .Include(d => d.Dinner)
                .Include(d => d.Lunch)
                .Include(d => d.SecondBreakfast)
                .Include(d => d.Snack)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diet == null)
            {
                return NotFound();
            }

            return View(diet);
        }

        // POST: Diets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diet = await _context.Diets.FindAsync(id);
            if (diet != null)
            {
                _context.Diets.Remove(diet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DietExists(int id)
        {
            return _context.Diets.Any(e => e.Id == id);
        }
    }
}
