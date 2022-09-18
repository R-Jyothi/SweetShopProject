using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineSweetShop.Models;

namespace OnlineSweetShop.Controllers
{
    public class SweetCategoriesController : Controller
    {
        private readonly SweetContext _context;

        public SweetCategoriesController(SweetContext context)
        {
            _context = context;
        }

        // GET: SweetCategories
        public async Task<IActionResult> Index()
        {
              return _context.SweetCategories != null ? 
                          View(await _context.SweetCategories.ToListAsync()) :
                          Problem("Entity set 'SweetContext.SweetCategories'  is null.");
        }

        public ActionResult SelectCategory()
        {
            return _context.SweetCategories != null ?
                                   View(_context.SweetCategories.ToList()) :
                                   Problem("Entity set 'SweetContext.SweetCategories'  is null.");
        }


            // GET: SweetCategories/Details/5
            public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SweetCategories == null)
            {
                return NotFound();
            }

            var sweetCategory = await _context.SweetCategories
                .FirstOrDefaultAsync(m => m.id == id);
            if (sweetCategory == null)
            {
                return NotFound();
            }

            return View(sweetCategory);
        }

        // GET: SweetCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SweetCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,description,photopath")] SweetCategory sweetCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sweetCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sweetCategory);
        }

        // GET: SweetCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SweetCategories == null)
            {
                return NotFound();
            }

            var sweetCategory = await _context.SweetCategories.FindAsync(id);
            if (sweetCategory == null)
            {
                return NotFound();
            }
            return View(sweetCategory);
        }

        // POST: SweetCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,description,photopath")] SweetCategory sweetCategory)
        {
            if (id != sweetCategory.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sweetCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SweetCategoryExists(sweetCategory.id))
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
            return View(sweetCategory);
        }

        // GET: SweetCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SweetCategories == null)
            {
                return NotFound();
            }

            var sweetCategory = await _context.SweetCategories
                .FirstOrDefaultAsync(m => m.id == id);
            if (sweetCategory == null)
            {
                return NotFound();
            }

            return View(sweetCategory);
        }

        // POST: SweetCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SweetCategories == null)
            {
                return Problem("Entity set 'SweetContext.SweetCategories'  is null.");
            }
            var sweetCategory = await _context.SweetCategories.FindAsync(id);
            if (sweetCategory != null)
            {
                _context.SweetCategories.Remove(sweetCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SweetCategoryExists(int id)
        {
          return (_context.SweetCategories?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
