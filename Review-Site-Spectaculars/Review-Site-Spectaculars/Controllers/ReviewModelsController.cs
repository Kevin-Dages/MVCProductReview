using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Review_Site_Spectaculars;
using Review_Site_Spectaculars.Models;

namespace Review_Site_Spectaculars.Controllers
{
    public class ReviewModelsController : Controller
    {
        private readonly ReviewContext _context;

        public ReviewModelsController(ReviewContext context)
        {
            _context = context;
        }

        // GET: ReviewModels
        public async Task<IActionResult> Index()
        {
            var reviewContext = _context.ReviewModel.Include(r => r.Product);
            return View(await reviewContext.ToListAsync());
        }

        // GET: ReviewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ReviewModel == null)
            {
                return NotFound();
            }

            var reviewModel = await _context.ReviewModel
                .Include(r => r.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reviewModel == null)
            {
                return NotFound();
            }

            return View(reviewModel);
        }

        // GET: ReviewModels/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.ProductModels, "Id", "Name");
            return View();
        }

        // POST: ReviewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReviewerName,Content,ProductId")] ReviewModel reviewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reviewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.ProductModels, "Id", "Name");
            return View(reviewModel);
        }

        // GET: ReviewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ReviewModel == null)
            {
                return NotFound();
            }

            var reviewModel = await _context.ReviewModel.FindAsync(id);
            if (reviewModel == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.ProductModels, "Id", "Name");
            return View(reviewModel);
        }

        // POST: ReviewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReviewerName,Content,ProductId")] ReviewModel reviewModel)
        {
            if (id != reviewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reviewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewModelExists(reviewModel.Id))
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
            ViewData["ProductId"] = new SelectList(_context.ProductModels, "Id", "Name");
            return View(reviewModel);
        }

        // GET: ReviewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ReviewModel == null)
            {
                return NotFound();
            }

            var reviewModel = await _context.ReviewModel
                .Include(r => r.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reviewModel == null)
            {
                return NotFound();
            }

            return View(reviewModel);
        }

        // POST: ReviewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ReviewModel == null)
            {
                return Problem("Entity set 'ReviewContext.ReviewModel'  is null.");
            }
            var reviewModel = await _context.ReviewModel.FindAsync(id);
            if (reviewModel != null)
            {
                _context.ReviewModel.Remove(reviewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewModelExists(int id)
        {
          return _context.ReviewModel.Any(e => e.Id == id);
        }
    }
}
