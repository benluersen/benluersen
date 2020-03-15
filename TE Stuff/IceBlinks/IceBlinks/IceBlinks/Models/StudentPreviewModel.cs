using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IceBlinks.Models
{
    public class StudentPreviewModel
    {
        [Required(ErrorMessage = "First name is required")]
        [MaxLength(64, ErrorMessage = "Name is too long")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(64, ErrorMessage = "Name is too long")]
        public string LastName { get; set; }

        [EmailAddress]
        [MaxLength(64, ErrorMessage = "Email is too long")]
        public string Email { get; set; }

        [Phone]
        [MaxLength(20, ErrorMessage = "Phone number is too long")]
        public string Phone { get; set; }

        [MaxLength(6, ErrorMessage = "Too long")]
        public string ContactPreference { get; set; }

        public int Cohort { get; set; }

        public int Id { get; set; }
    }
}
