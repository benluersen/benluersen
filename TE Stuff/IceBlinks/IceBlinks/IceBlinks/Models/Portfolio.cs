using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IceBlinks.Models
{
    public class Portfolio
    {
        public int Id { get; set; }

        public int ProfileId { get; set; }
        
        [MaxLength(128, ErrorMessage = "Too long")]
        public string ProjectTitle { get; set; }

        public string ProjectDescription { get; set; }

        [MaxLength(128, ErrorMessage = "Link too long, please find a shorter one")]
        public string ProjectLink { get; set; }


        private List<Tech> _techUsed;
        public List<Tech> TechnologiesUsed
        {
            get
            {
                if (_techUsed == null && TechNames != null)
                {
                    _techUsed = TechNameStringToList(TechNames);
                }
                return _techUsed;
            }
            set
            {
                _techUsed = value;
                if (value != null)
                {
                    TechNames = TechNameListToString(value);
                }
            }
        }
        
        public string TechNames { get; set; }

        private List<Tech> TechNameStringToList(string techNames)
        {
            List<Tech> techList = new List<Tech>();
            string[] techNameSplit = techNames.Split(", ");
            foreach (var tech in techNameSplit)
            {
                if (tech != "" && tech != " ")
                {
                    Tech t = new Tech();
                    t.TechName = tech;
                    techList.Add(t);
                }
            }
            return techList;
        }

        private string TechNameListToString(List<Tech> techNames)
        {
            string techString = "";
            for(int i = 0; i < techNames.Count; i++)
            {
                if (i == 0)
                {
                    techString += techNames[i].TechName;
                }
                else
                {
                    techString += ", " + techNames[i].TechName;
                }
            }
            return techString;
        }
    }
}
