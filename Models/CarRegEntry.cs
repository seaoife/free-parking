﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreePark.Models
{
    public class CarRegEntry
    {

        public int Id { get; set; }
        public string CarReg { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }



    }
}
