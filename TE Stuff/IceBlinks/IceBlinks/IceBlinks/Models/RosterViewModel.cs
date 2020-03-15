using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IceBlinks.Models
{
    public class RosterViewModel
    {
        public List<StudentPreviewModel> StudentPreviewList { get; set; }

        public int Cohort { get; set; } = -1;

        [MaxLength(35, ErrorMessage = "Too long")]
        public string Degree { get; set; }

        [MaxLength(64, ErrorMessage = "Too long")]
        public string Industry { get; set; }

        [MaxLength(32, ErrorMessage = "Too long")]
        public string TechName { get; set; }

        public List<SelectListItem> TechList { get; set; }

        public List<SelectListItem> IndustryList { get; set; }

        public List<SelectListItem> CohortList { get; set; }

        public List<SelectListItem> DegreeList { get; set; }

        public int Id { get; set; }

        public bool ExclusiveSearch { get; set; }
    }
}
