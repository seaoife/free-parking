using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace FreePark.Models
{
    public class CarDetails
    {
        public int Id { get; set; }
       
       // [ForeignKey("UserId")]
       //public ApplicationUser UserId { get; set; }
    }
}
