using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FreePark.Models
{
    public class Venue
    {
        [Key]
        public int VenueId { get; set; }

        public string VenueName { get; set; }
        public float GarageLat { get; set; }
        public float GarageLong { get; set; }
        public string VenueImage { get; set; }

        public string VenueNotes { get; set; }

    }
}
