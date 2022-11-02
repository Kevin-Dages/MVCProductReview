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
    public class ProductModelsController : Controller
    {
        private readonly ReviewContext _context;

        public ProductModelsController(ReviewContext context)
        {
            _context = context;
        }

        // GET: ProductModels
        public async Task<IActionResult> Index()
        {
              return View(await _context.ProductModels.ToListAsync());
        }

        // GET: ProductModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductModels == null)
            {
                return NotFound();
            }

            var productModels = await _context.ProductModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productModels == null)
            {
                return NotFound();
            }

            return View(productModels);
        }

        // GET: ProductModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Image,Description")] ProductModels productModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productModels);
        }

        // GET: ProductModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductModels == null)
            {
                return NotFound();
            }

            var productModels = await _context.ProductModels.FindAsync(id);
            if (productModels == null)
            {
                return NotFound();
            }
            return View(productModels);
        }

        // POST: ProductModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Image,Description")] ProductModels productModels)
        {
            if (id != productModels.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductModelsExists(productModels.Id))
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
            return View(productModels);
        }

        // GET: ProductModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductModels == null)
            {
                return NotFound();
            }

            var productModels = await _context.ProductModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productModels == null)
            {
                return NotFound();
            }

            return View(productModels);
        }

        // POST: ProductModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductModels == null)
            {
                return Problem("Entity set 'ReviewContext.ProductModels'  is null.");
            }
            var productModels = await _context.ProductModels.FindAsync(id);
            if (productModels != null)
            {
                _context.ProductModels.Remove(productModels);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductModelsExists(int id)
        {
          return _context.ProductModels.Any(e => e.Id == id);
        }
    }
}
