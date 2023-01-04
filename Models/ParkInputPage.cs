using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreePark.Models
{
    public class ParkInputPage
    {
        public int Id { get; set; }
        public Boolean FreeParkingCheckBox { get; set; }
        public Boolean GarageParkingCheckbox { get; set; }
        public Boolean ParkingMeterLocations { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string StreetName { get; set; }
        public string Venue { get; set; }
        public string LocationSelect { get; set; }



    }
}
