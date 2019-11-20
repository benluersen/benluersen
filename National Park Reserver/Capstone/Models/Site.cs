using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Site
    {
        public int site_id { get; set; } = 0;
        public int campground_id { get; set; } = 0;
        public int site_number { get; set; } = 0;
        public int max_occupancy { get; set; } = 0;
        public int max_rv_length { get; set; } = 0;
        public bool utilities { get; set; } = false;
    }
}
