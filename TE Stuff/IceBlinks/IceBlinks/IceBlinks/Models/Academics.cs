using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace IceBlinks.Models
{
    public class Academics
    {
        public int Id { get; set; } = -1;
        public int ProfileId { get; set; } = -1;

        [MaxLength(35, ErrorMessage = "Too long")]
        public string Degree { get; set; }

        [MaxLength(64, ErrorMessage = "Too long")]
        public string Institution { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public bool Graduated { get; set; }

        [MaxLength(64, ErrorMessage = "Too long")]
        public string Major { get; set; }

    }
}
