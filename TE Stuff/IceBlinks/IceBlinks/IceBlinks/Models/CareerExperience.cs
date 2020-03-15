using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IceBlinks.Models
{
    public class CareerExperience
    {
        [Required]
        public int Id { get; set; } = -1;
        public int ProfileId { get; set; } = -1;

        [Required]
        [MaxLength(64, ErrorMessage = "Too long")]
        public string Title { get; set; }

        [Required]
        [MaxLength(128, ErrorMessage = "Too long")]
        public string Employer { get; set; }

        [Required]
        [MaxLength(64, ErrorMessage = "Too long")]
        public string Industry { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        //public bool Employed { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Too long")]
        public string JobDescription { get; set; }
    }
}
