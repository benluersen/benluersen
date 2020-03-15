using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IceBlinks.Models
{
    public class Profile
    {
        public int Cohort { get; set; }

        public string Summary { get; set; }

        [MaxLength(255, ErrorMessage = "Too long")]
        public string SoftSkills { get; set; }

        [MaxLength(450, ErrorMessage = "Too long")]
        public string Interests { get; set; }

        [MaxLength(255, ErrorMessage = "Too long")]
        public string PhotoLink { get; set; }

        public bool Searchable { get; set; }

        [MaxLength(6, ErrorMessage = "Too long")]
        public string ContactPreference { get; set; }

        public List<Academics> AcademicsList { get; set; }
        public List<CareerExperience> CareerExperienceList { get; set; }
        public List<Portfolio> PortfolioProjects { get; set; }
        public List<Tech> TechList { get; set; }
    }
}

