using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IceBlinks.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First name is required")]
        [MaxLength(64, ErrorMessage = "Name is too long")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(64, ErrorMessage = "Name is too long")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress]
        [MaxLength(64, ErrorMessage = "Email is too long")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(64, ErrorMessage = "Password is too long")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Passwords must match")]
        [MaxLength(64, ErrorMessage = "Password is too long")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [Phone]
        [MaxLength(20, ErrorMessage = "Phone number is too long")]
        public string Phone { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Address too long")]
        public string UserAddress { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "City name too long")]
        public string City { get; set; }

        [Required]
        [MaxLength(2, ErrorMessage = "Please select a state")]
        public string State { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Phone number is too long")]
        public string PostalCode { get; set; }

        [Required]
        [Range(2, 3, ErrorMessage = "Must choose either student or employee")]
        public int RoleId { get; set; }

        [Required]
        public int Id { get; set; }
    }
}