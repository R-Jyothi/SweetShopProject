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
    public class OffersController : Controller
    {
        private readonly SweetContext _context;

        public OffersController(SweetContext context)
        {
            _context = context;
        }

        // GET: Offers
        public async Task<IActionResult> Index()
        {
            var sweetContext = _context.Offers.Include(o => o.Product);
            return View(await sweetContext.ToListAsync());
        }

        public IActionResult ViewOfferx(int id)
        {
            var sweetContext = _context.Offers.Include(o => o.Product);
            return View(sweetContext.ToList());
        }

        // GET: Offers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Offers == null)
            {
                return NotFound();
            }

            var offer = await _context.Offers
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.id == id);
            if (offer == null)
            {
                return NotFound();
            }

            return View(offer);
        }

        // GET: Offers/Create
        public IActionResult Create()
        {
            ViewData["prodID"] = new SelectList(_context.SweetProducts, "id", "name");
            return View();
        }

        // POST: Offers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,prodID,AmountType,offer,sdate,edate")] Offer off)
        {
            if (ModelState.IsValid)
            {
                _context.Add(off);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["prodID"] = new SelectList(_context.SweetProducts, "id", "name", off.prodID);
            return View(off);
        }

        // GET: Offers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Offers == null)
            {
                return NotFound();
            }

            var offer = await _context.Offers.FindAsync(id);
            if (offer == null)
            {
                return NotFound();
            }
            ViewData["prodID"] = new SelectList(_context.SweetProducts, "id", "id", offer.prodID);
            return View(offer);
        }

        // POST: Offers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,prodID,AmountType,offer,sdate,edate")] Offer offer)
        {
            if (id != offer.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(offer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfferExists(offer.id))
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
            ViewData["prodID"] = new SelectList(_context.SweetProducts, "id", "id", offer.prodID);
            return View(offer);
        }

        // GET: Offers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Offers == null)
            {
                return NotFound();
            }

            var offer = await _context.Offers
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.id == id);
            if (offer == null)
            {
                return NotFound();
            }

            return View(offer);
        }

        // POST: Offers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Offers == null)
            {
                return Problem("Entity set 'SweetContext.Offers'  is null.");
            }
            var offer = await _context.Offers.FindAsync(id);
            if (offer != null)
            {
                _context.Offers.Remove(offer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfferExists(int id)
        {
          return (_context.Offers?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
