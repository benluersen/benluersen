using ParkGeekMVC.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkGeek.DAL.Models
{
    public class Surveys
    {
        public Park Park { get; set; }
        public int NumberOfReviews { get; set; }
    }
}
