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
        public int TotalSpace { get; set; }
        public string Venue { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public bool IsGarageParking { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public string Notes { get; set; }

    }
}
