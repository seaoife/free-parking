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
    public class GarageParkingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GarageParkingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GarageParkings
        public async Task<IActionResult> Index()
        {
            return View(await _context.GarageParking.ToListAsync());
        }

        // GET: GarageParkings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garageParking = await _context.GarageParking
                .FirstOrDefaultAsync(m => m.GarageId == id);
            if (garageParking == null)
            {
                return NotFound();
            }

            return View(garageParking);
        }

        // GET: GarageParkings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GarageParkings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GarageId,GarageName,GarageLat,GarageLong")] GarageParking garageParking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(garageParking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(garageParking);
        }

        // GET: GarageParkings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garageParking = await _context.GarageParking.FindAsync(id);
            if (garageParking == null)
            {
                return NotFound();
            }
            return View(garageParking);
        }

        // POST: GarageParkings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GarageId,GarageName,GarageLat,GarageLong")] GarageParking garageParking)
        {
            if (id != garageParking.GarageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(garageParking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GarageParkingExists(garageParking.GarageId))
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
            return View(garageParking);
        }

        // GET: GarageParkings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garageParking = await _context.GarageParking
                .FirstOrDefaultAsync(m => m.GarageId == id);
            if (garageParking == null)
            {
                return NotFound();
            }

            return View(garageParking);
        }

        // POST: GarageParkings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var garageParking = await _context.GarageParking.FindAsync(id);
            _context.GarageParking.Remove(garageParking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GarageParkingExists(int id)
        {
            return _context.GarageParking.Any(e => e.GarageId == id);
        }
    }
}
