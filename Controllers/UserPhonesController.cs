using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FreePark.Data;
using FreePark.Models;

namespace FreePark.Controllers
{
    public class UserPhonesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserPhonesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserPhones
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserPhone.ToListAsync());
        }

        // GET: UserPhones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPhone = await _context.UserPhone
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userPhone == null)
            {
                return NotFound();
            }

            return View(userPhone);
        }

        // GET: UserPhones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserPhones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,PhoneNumber")] UserPhone userPhone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userPhone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userPhone);
        }

        // GET: UserPhones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPhone = await _context.UserPhone.FindAsync(id);
            if (userPhone == null)
            {
                return NotFound();
            }
            return View(userPhone);
        }

        // POST: UserPhones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,PhoneNumber")] UserPhone userPhone)
        {
            if (id != userPhone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userPhone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserPhoneExists(userPhone.Id))
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
            return View(userPhone);
        }

        // GET: UserPhones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPhone = await _context.UserPhone
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userPhone == null)
            {
                return NotFound();
            }

            return View(userPhone);
        }

        // POST: UserPhones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userPhone = await _context.UserPhone.FindAsync(id);
            _context.UserPhone.Remove(userPhone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserPhoneExists(int id)
        {
            return _context.UserPhone.Any(e => e.Id == id);
        }
    }
}
