using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreePark.Models
{
    public class ParkingSpace
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public float StreetStartlat { get; set; }
        public float StreetStartlong { get; set; }
        public float StreetEndlat { get; set; }
        public float StreetEndlng { get; set; }
        public int TotalSpace { get; set; }
        public string Venue { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public float PMLocation1lat { get; set; }
        public float PMLocation1lng { get; set; }
        public bool IsGarageParking { get; set; }
        public bool HasParkingMeterLocations { get; set; }
        public bool IsFreeParking { get; set; }
        public int StartDay { get; set; }
        public int EndDay { get; set; }
        public float StartTime { get; set; }
        public float EndTime { get; set; }
        public string Notes { get; set; }  
        public float free_paidlat { get; set; }
        public float free_paidlng { get; set; }

    }
}
