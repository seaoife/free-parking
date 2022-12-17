using FreePark.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreePark.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ParkingSpace> ParkingSpaces { get; set; }

        public DbSet<FreePark.Models.UserPhone> UserPhone { get; set; }

        public DbSet<FreePark.Models.CarRegEntry> CarRegEntry { get; set; }

        public DbSet<FreePark.Models.CarDetails> CarDetails { get; set; }

        public DbSet<FreePark.Models.ParkInputPage> ParkInputPage { get; set; }

        public DbSet<FreePark.Models.GarageParking> GarageParking { get; set; }

        public DbSet<FreePark.Models.Venue> Venue { get; set; }

      

       

        

        
         
    }
}
