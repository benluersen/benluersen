using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Park
    {
        public int park_id { get; set; } = 0;
        public string name { get; set; }
        public string location { get; set; }
        public DateTime establishDate { get; set; }
        public int area { get; set; } = 0;
        public int visitors { get; set; } = 0;
        public string description { get; set; }
    }
}
