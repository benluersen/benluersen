using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Campground
    {
        public int campground_id { get; set; } = 0;
        public int park_id { get; set; } = 0;
        public string name { get; set; }
        public int open_from_mm { get; set; } = 0;
        public int open_to_mm { get; set; } = 0;
        public decimal daily_fee { get; set; } = 0;
    }
}
