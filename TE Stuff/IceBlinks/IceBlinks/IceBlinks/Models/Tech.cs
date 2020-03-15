using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IceBlinks.Models
{
    public class Tech
    {
        public int Id { get; set; }
        [MaxLength(32, ErrorMessage = "Too long")]
        public string TechName { get; set; }
    }
}
