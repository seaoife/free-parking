using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreePark.Models
{
    public class ParkInputPage
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public string LocationSelect { get; set; }
        
        public string ParkNearVenueSelect { get; set; }
        public Boolean FreeParkingCheckBox { get; set; }
        public Boolean GarageParkingCheckbox { get; set;}

        public Boolean ParkingMeterLocations { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }


    }
}
