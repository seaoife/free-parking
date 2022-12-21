using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FreePark.Data;
using FreePark.Models;
using Microsoft.AspNetCore.Identity;

namespace FreePark.Controllers
{
    public class CarRegEntriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;// added user manager to have access to teh userId

        public CarRegEntriesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)//added another parameter of user manager
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: CarRegEntries
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarRegEntry.ToListAsync());
        }

        // GET: CarRegEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carRegEntry = await _context.CarRegEntry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carRegEntry == null)
            {
                return NotFound();
            }

            return View(carRegEntry);
        }

        // GET: CarRegEntries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarRegEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarReg,UserId")] CarRegEntry carRegEntry)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                carRegEntry.UserId = user.Id;//"3d1a3723-c31a-450d-a28b-99e3e3c3fc99";
                _context.Add(carRegEntry);//added carreg entry so that when a valid registration is made the carreg will save also
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carRegEntry);
        }

        // GET: CarRegEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carRegEntry = await _context.CarRegEntry.FindAsync(id);
            if (carRegEntry == null)
            {
                return NotFound();
            }
            return View(carRegEntry);
        }

        // POST: CarRegEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarReg,UserId")] CarRegEntry carRegEntry)
        {
            if (id != carRegEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carRegEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarRegEntryExists(carRegEntry.Id))
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
            return View(carRegEntry);
        }

        // GET: CarRegEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carRegEntry = await _context.CarRegEntry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carRegEntry == null)
            {
                return NotFound();
            }

            return View(carRegEntry);
        }

        // POST: CarRegEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carRegEntry = await _context.CarRegEntry.FindAsync(id);
            _context.CarRegEntry.Remove(carRegEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarRegEntryExists(int id)
        {
            return _context.CarRegEntry.Any(e => e.Id == id);
        }
    }
}
