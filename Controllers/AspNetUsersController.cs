using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineSweetShop.Models;

namespace OnlineSweetShop.Controllers
{
    //[Authorize]
    public class AspNetUsersController : Controller
    {
        private readonly SweetContext _context;
        //private readonly IHttpContextAccessor _contextAccessor;

        public AspNetUsersController(SweetContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            //_contextAccessor = contextAccessor;
        }

        // GET: AspNetUsers
        public async Task<IActionResult> Index()
        {
            //return _context.aspNetUsers != null ? 
            return View(await _context.aspNetUsers.ToListAsync());
                          //Problem("Entity set 'SweetContext.aspNetUsers'  is null.");
        }

        
        // GET: AspNetUsers/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null || _context.aspNetUsers == null)
            {
                return NotFound();
            }

            var aspNetUser = await _context.aspNetUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspNetUser == null)
            {
                return NotFound();
            }

            return View(aspNetUser);
        }

        // GET: AspNetUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AspNetUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,MiddleName,LastName,Gender,Age,MobileNumber,Address,City,District,State,ZipCode,Role")] AspNetUser aspNetUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aspNetUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aspNetUser);
        }

        // GET: AspNetUsers/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            //var UserID = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //AspNetUser user = _context.aspNetUsers.Find(UserID);
            if (id == null || _context.aspNetUsers == null)
            {
                return NotFound();
            }

            var aspNetUser = await _context.aspNetUsers.FindAsync(id);
            if (aspNetUser == null)
            {
                return NotFound();
            }
            return View(aspNetUser);
            //return Ok();
        }

        // POST: AspNetUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FirstName,MiddleName,LastName,Gender,Age,MobileNumber,Address,City,District,State,ZipCode,Role")] AspNetUser aspNetUser)
        {
            if (id != aspNetUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aspNetUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AspNetUserExists(aspNetUser.Id))
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
            return View(aspNetUser);
        }

        // GET: AspNetUsers/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null || _context.aspNetUsers == null)
            {
                return NotFound();
            }

            var aspNetUser = await _context.aspNetUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspNetUser == null)
            {
                return NotFound();
            }

            return View(aspNetUser);
        }

        // POST: AspNetUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.aspNetUsers == null)
            {
                return Problem("Entity set 'SweetContext.aspNetUsers'  is null.");
            }
            var aspNetUser = await _context.aspNetUsers.FindAsync(id);
            if (aspNetUser != null)
            {
                _context.aspNetUsers.Remove(aspNetUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AspNetUserExists(string id)
        {
          return (_context.aspNetUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
