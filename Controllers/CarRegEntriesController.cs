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
    public class CarRegEntriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarRegEntriesController(ApplicationDbContext context)
        {
            _context = context;
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
                _context.Add(carRegEntry);
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
