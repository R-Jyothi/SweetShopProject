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
    public class EventBookingReqsController : Controller
    {
        private readonly SweetContext _context;

        public EventBookingReqsController(SweetContext context)
        {
            _context = context;
        }

        // GET: EventBookingReqs
        public async Task<IActionResult> Index()
        {
              return _context.EventBookingReqs != null ? 
                          View(await _context.EventBookingReqs.ToListAsync()) :
                          Problem("Entity set 'SweetContext.EventBookingReqs'  is null.");
        }

       

        // GET: EventBookingReqs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EventBookingReqs == null)
            {
                return NotFound();
            }

            var eventBookingReq = await _context.EventBookingReqs
                .FirstOrDefaultAsync(m => m.id == id);
            if (eventBookingReq == null)
            {
                return NotFound();
            }

            return View(eventBookingReq);
        }

        // GET: EventBookingReqs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventBookingReqs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,productNames,address,dateofdelivery,mob")] EventBookingReq eventBookingReq)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventBookingReq);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventBookingReq);
        }

        // GET: EventBookingReqs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EventBookingReqs == null)
            {
                return NotFound();
            }

            var eventBookingReq = await _context.EventBookingReqs.FindAsync(id);
            if (eventBookingReq == null)
            {
                return NotFound();
            }
            return View(eventBookingReq);
        }

        // POST: EventBookingReqs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,productNames,address,dateofdelivery,mob")] EventBookingReq eventBookingReq)
        {
            if (id != eventBookingReq.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventBookingReq);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventBookingReqExists(eventBookingReq.id))
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
            return View(eventBookingReq);
        }

        // GET: EventBookingReqs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EventBookingReqs == null)
            {
                return NotFound();
            }

            var eventBookingReq = await _context.EventBookingReqs
                .FirstOrDefaultAsync(m => m.id == id);
            if (eventBookingReq == null)
            {
                return NotFound();
            }

            return View(eventBookingReq);
        }

        // POST: EventBookingReqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EventBookingReqs == null)
            {
                return Problem("Entity set 'SweetContext.EventBookingReqs'  is null.");
            }
            var eventBookingReq = await _context.EventBookingReqs.FindAsync(id);
            if (eventBookingReq != null)
            {
                _context.EventBookingReqs.Remove(eventBookingReq);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventBookingReqExists(int id)
        {
          return (_context.EventBookingReqs?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
