using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkGeekMVC.Models
{
    public class SurveyResult
    {
        [Required]
        public string ParkCode { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }
        [Required(ErrorMessage = "Activity Level is required")]
        public string ActivityLevel { get; set; }

        
    }
}
