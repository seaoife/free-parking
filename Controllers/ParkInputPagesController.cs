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
    public class ParkInputPagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParkInputPagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ParkInputPages
        public async Task<IActionResult> Index()
        {
            return View(await _context.ParkInputPage.ToListAsync());
        }

        // GET: ParkInputPages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkInputPage = await _context.ParkInputPage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkInputPage == null)
            {
                return NotFound();
            }

            return View(parkInputPage);
        }

        // GET: ParkInputPages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParkInputPages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,LocationSelect,ParkNearVenueSelect,FreeParkingCheckBox,GarageParkingCheckbox,ParkingMeterLocations")] ParkInputPage parkInputPage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parkInputPage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parkInputPage);
        }

        // GET: ParkInputPages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkInputPage = await _context.ParkInputPage.FindAsync(id);
            if (parkInputPage == null)
            {
                return NotFound();
            }
            return View(parkInputPage);
        }

        // POST: ParkInputPages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,LocationSelect,ParkNearVenueSelect,FreeParkingCheckBox,GarageParkingCheckbox,ParkingMeterLocations")] ParkInputPage parkInputPage)
        {
            if (id != parkInputPage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkInputPage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkInputPageExists(parkInputPage.Id))
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
            return View(parkInputPage);
        }

        // GET: ParkInputPages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkInputPage = await _context.ParkInputPage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkInputPage == null)
            {
                return NotFound();
            }

            return View(parkInputPage);
        }

        // POST: ParkInputPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parkInputPage = await _context.ParkInputPage.FindAsync(id);
            _context.ParkInputPage.Remove(parkInputPage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkInputPageExists(int id)
        {
            return _context.ParkInputPage.Any(e => e.Id == id);
        }
    }
}
