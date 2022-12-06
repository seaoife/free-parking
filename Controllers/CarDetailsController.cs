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
    public class CarDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CarDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarDetails.ToListAsync());
        }

        // GET: CarDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carDetails = await _context.CarDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carDetails == null)
            {
                return NotFound();
            }

            return View(carDetails);
        }

        // GET: CarDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] CarDetails carDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carDetails);
        }

        // GET: CarDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carDetails = await _context.CarDetails.FindAsync(id);
            if (carDetails == null)
            {
                return NotFound();
            }
            return View(carDetails);
        }

        // POST: CarDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] CarDetails carDetails)
        {
            if (id != carDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarDetailsExists(carDetails.Id))
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
            return View(carDetails);
        }

        // GET: CarDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carDetails = await _context.CarDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carDetails == null)
            {
                return NotFound();
            }

            return View(carDetails);
        }

        // POST: CarDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carDetails = await _context.CarDetails.FindAsync(id);
            _context.CarDetails.Remove(carDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarDetailsExists(int id)
        {
            return _context.CarDetails.Any(e => e.Id == id);
        }
    }
}
