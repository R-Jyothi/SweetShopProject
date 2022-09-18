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
    public class SweetProductsController : Controller
    {
        private readonly SweetContext _context;

        public SweetProductsController(SweetContext context)
        {
            _context = context;
        }

        // GET: SweetProducts
        public async Task<IActionResult> Index()
        {
            var sweetContext = _context.SweetProducts.Include(s => s.categ);
            return View(await sweetContext.ToListAsync());
        }

        public ActionResult ProductList(int id)
        {
            var sweetContext = _context.SweetProducts.Include(s => s.categ).Where(e=>e.categID==id);
            return View(sweetContext.ToList());
        }

        // GET: SweetProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SweetProducts == null)
            {
                return NotFound();
            }

            var sweetProduct = await _context.SweetProducts
                .Include(s => s.categ)
                .FirstOrDefaultAsync(m => m.id == id);
            if (sweetProduct == null)
            {
                return NotFound();
            }

            return View(sweetProduct);
        }

        // GET: SweetProducts/Create
        public IActionResult Create()
        {
            ViewData["categID"] = new SelectList(_context.SweetCategories, "id", "id");
            return View();
        }

        // POST: SweetProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,categID,price")] SweetProduct sweetProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sweetProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["categID"] = new SelectList(_context.SweetCategories, "id", "id", sweetProduct.categID);
            return View(sweetProduct);
        }

        // GET: SweetProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SweetProducts == null)
            {
                return NotFound();
            }

            var sweetProduct = await _context.SweetProducts.FindAsync(id);
            if (sweetProduct == null)
            {
                return NotFound();
            }
            ViewData["categID"] = new SelectList(_context.SweetCategories, "id", "id", sweetProduct.categID);
            return View(sweetProduct);
        }

        // POST: SweetProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,categID,price")] SweetProduct sweetProduct)
        {
            if (id != sweetProduct.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sweetProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SweetProductExists(sweetProduct.id))
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
            ViewData["categID"] = new SelectList(_context.SweetCategories, "id", "id", sweetProduct.categID);
            return View(sweetProduct);
        }

        // GET: SweetProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SweetProducts == null)
            {
                return NotFound();
            }

            var sweetProduct = await _context.SweetProducts
                .Include(s => s.categ)
                .FirstOrDefaultAsync(m => m.id == id);
            if (sweetProduct == null)
            {
                return NotFound();
            }

            return View(sweetProduct);
        }

        // POST: SweetProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SweetProducts == null)
            {
                return Problem("Entity set 'SweetContext.SweetProducts'  is null.");
            }
            var sweetProduct = await _context.SweetProducts.FindAsync(id);
            if (sweetProduct != null)
            {
                _context.SweetProducts.Remove(sweetProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SweetProductExists(int id)
        {
          return (_context.SweetProducts?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
