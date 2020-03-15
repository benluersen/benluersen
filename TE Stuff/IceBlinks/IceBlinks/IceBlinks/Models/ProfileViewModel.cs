using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IceBlinks.Models
{
    public class ProfileViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [MaxLength(64, ErrorMessage = "Name is too long")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(64, ErrorMessage = "Name is too long")]
        public string LastName { get; set; }

        [EmailAddress]
        [MaxLength(64, ErrorMessage = "Email is too long")]
        public string Email { get; set; }

        private string _phone;

        [Phone]
        [MaxLength(20, ErrorMessage = "Phone number is too long")]
        public string Phone
        {
            get
            {
                string phone = _phone;
                if (!_phone.Contains("-") && !_phone.Contains(")") && !_phone.Contains("("))
                {
                    phone = String.Format("{0:(###) ###-####}", _phone);
                }
                return phone;
            }
            set { _phone = value; }
        }

        public string Address { get; set; }

        public string City { get; set; }

        public int UserId { get; set; }

        public string Role { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        [Range(-1, int.MaxValue, ErrorMessage = "Not a valid cohort number")]
        public int Cohort { get; set; }

        public string Summary { get; set; }

        [MaxLength(255, ErrorMessage = "Too long")]
        public string SoftSkills { get; set; }

        [MaxLength(450, ErrorMessage = "Too long")]
        public string Interests { get; set; }

        [MaxLength(255, ErrorMessage = "Too long")]
        public string PhotoLink { get; set; }

        public bool Searchable { get; set; } = false;

        [MaxLength(6, ErrorMessage = "Too long")]
        public string ContactPreference { get; set; }

        public List<Academics> AcademicsList { get; set; }
        public List<CareerExperience> CareerExperienceList { get; set; }
        public List<Portfolio> PortfolioProjects { get; set; }
        public List<Tech> TechList { get; set; }
    }
}