using Security.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Security.BusinessLogic
{
    /// <summary>
    /// Handles the user authorization
    /// </summary>
    public class Authorization
    {
        /// <summary>
        /// The available user roles
        /// </summary>
        public enum eRole
        {
            Unknown = 0,
            Administrator = 1,
            Student = 2,
            Employer = 3,
            Staff = 4
        }

        /// <summary>
        /// The user to manage permissions for
        /// </summary>
        public UserItem User { get; set; }

        public Authorization(UserItem user)
        {
            User = user;
        }

        /// <summary>
        /// The name of the user's role
        /// </summary>
        private eRole RoleName
        {
            get
            {
                return User != null ? (eRole)User.RoleId : eRole.Unknown;
            }
        }

        /// <summary>
        /// Specifies if the user has administrator permissions
        /// </summary>
        public bool IsAdministrator
        {
            get
            {
                return RoleName == eRole.Administrator;
            }
        }

        /// <summary>
        /// Specifies if the user has Student permissions
        /// </summary>
        public bool IsStudent
        {
            get
            {
                return RoleName == eRole.Student;
            }
        }

        /// <summary>
        /// Specifies if the user has Employer permissions
        /// </summary>
        public bool IsEmployer
        {
            get
            {
                return RoleName == eRole.Employer;
            }
        }

        /// <summary>
        /// Specifies if the user has Instructor permissions
        /// </summary>
        public bool IsStaff
        {
            get
            {
                return RoleName == eRole.Staff;
            }
        }
        /// <summary>
        /// Specifies if the user has unknown permissions
        /// </summary>
        public bool IsUnknown
        {
            get
            {
                return RoleName == eRole.Unknown;
            }
        }
    }
}
