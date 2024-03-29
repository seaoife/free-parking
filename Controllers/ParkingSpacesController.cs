﻿using System;
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
    public class ParkingSpacesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParkingSpacesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ParkingSpaces
        public async Task<IActionResult> Index()
        {
            return View(await _context.ParkingSpaces.ToListAsync());
        }

        public async Task<JsonResult> GetStreets()
        {
            // fetching all parkings spaces and converting it to json.function for conver
            return Json(await _context.ParkingSpaces.ToListAsync());
        }

        // fetching garage parkings as json
        public async Task<JsonResult> GetGarageParkings()
        {
            // fetching all parkings spaces and converting it to json
            return Json(await _context.GarageParking.ToListAsync());
        }

        //https://localhost:44361/ParkingSpaces/SearchForMap?StreetName=gra&Venue=stripe
        public async Task<JsonResult> SearchForMap(ParkInputPage parkInputPage)
        {
            var result = _context.ParkingSpaces
                .Where(p => EF.Functions.Like(p.StreetName, "%" + parkInputPage.StreetName + "%"))
                .Where(p => EF.Functions.Like(p.Venue, "%" + parkInputPage.Venue + "%"))
                .ToList();

            return Json(result);//then returns the Index view
        }

        //public async Task<JsonResult> SearchForVenue(ParkInputPage parkInputPage)
        //{
        //    var result = _context.ParkingSpaces
        //        .Where(p => EF.Functions.Like(p.Venue, "%" + parkInputPage.Venue + "%"))
        //        .ToList();

        //    return Json(result);//then returns the Index view
        //}
        public async Task<IActionResult> Map()
        {
            return View(await _context.ParkingSpaces.ToListAsync());
        }

        public IActionResult Search()
        {
            //var result = _context.ParkingSpaces.Where(p => p.StartTime >= 5).Where(p => p.IsGarageParking == false).ToList();

            //return View("Index", result);
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(ParkInputPage parkInputPage)
        {
            // will trigger this function when button in views/ParkingSpaces/Search is pressed
            // querying from parking spaces with given parameters: dayOfweek, GarageParkingCheckbox
            //var result = _context.ParkingSpaces
            //    .Where(p => p.StartTime >= (int)parkInputPage.StartTime.Hour)
            //    .Where(p => p.StartDay >= (int)parkInputPage.StartTime.DayOfWeek)
            //    // is boyne street name in db?
            //    // adds query for streetname as sql like from form of search view https://www.w3schools.com/sql/sql_like.asp
            //    .Where(p => EF.Functions.Like(p.StreetName, "%"+parkInputPage.StreetName+"%"))
            //    .ToList();

            //return View("Index", result);//then returns the Index view
            
            // redirect to Map Function
            return this.RedirectToAction("Map", new { StreetName = parkInputPage.StreetName, Venue = parkInputPage.Venue });
        }

        // GET: ParkingSpaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingSpace = await _context.ParkingSpaces
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkingSpace == null)
            {
                return NotFound();
            }

            return View(parkingSpace);
        }

        // GET: ParkingSpaces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParkingSpaces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StreetName,TotalSpace,Venue,lat,lng,IsGarageParking,StartTime,EndTime,Notes")] ParkingSpace parkingSpace)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parkingSpace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parkingSpace);
        }

        // GET: ParkingSpaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingSpace = await _context.ParkingSpaces.FindAsync(id);
            if (parkingSpace == null)
            {
                return NotFound();
            }
            return View(parkingSpace);
        }

        // POST: ParkingSpaces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StreetName,TotalSpace,Venue,lat,lng,IsGarageParking,StartTime,EndTime,Notes")] ParkingSpace parkingSpace)
        {
            if (id != parkingSpace.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkingSpace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkingSpaceExists(parkingSpace.Id))
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
            return View(parkingSpace);
        }

        // GET: ParkingSpaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingSpace = await _context.ParkingSpaces
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkingSpace == null)
            {
                return NotFound();
            }

            return View(parkingSpace);
        }

        // POST: ParkingSpaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parkingSpace = await _context.ParkingSpaces.FindAsync(id);
            _context.ParkingSpaces.Remove(parkingSpace);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkingSpaceExists(int id)
        {
            return _context.ParkingSpaces.Any(e => e.Id == id);
        }
    }
}
