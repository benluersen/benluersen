using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IceBlinks.Models
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(64, ErrorMessage = "Email is too long")]
        public string Email { get; set; }

        [Required]
        [MaxLength(64, ErrorMessage = "Password is too long")]
        public string Password { get; set; }
    }
}