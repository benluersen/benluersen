﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Models
{
    /// <summary>
    /// Model needed to create a new UserItem in the DB
    /// </summary>
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}