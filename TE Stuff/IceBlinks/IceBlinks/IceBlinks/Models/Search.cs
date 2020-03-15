using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceBlinks.Models
{
    public class Search
    {
        public string Name { get; set; }
        public int Cohort { get; set; }
        public string Degree { get; set; }
        public string Industry { get; set; }
        public string TechName { get; set; }
        public bool ExOrIn { get; set; }

    }
}
