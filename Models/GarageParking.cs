using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FreePark.Models
{
    public class GarageParking
    {
        
        [Key]
        public int GarageId { get; set; }

        public string GarageName { get; set; }
        public float GarageLat { get; set; }
        public float GarageLong { get; set; }

    }
}
