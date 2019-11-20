using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class reservation
    {
        public int reservation_id { get; set; } = 0;
        public int site_id { get; set; } = 0;
        public string name { get; set; }
        public DateTime from_date { get; set; }
        public DateTime to_date { get; set; }
        public DateTime create_date { get; set; }
    }
}
