﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class User
    {
        /// <summary>
        /// The user's id.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// The user's username.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        /// <summary>
        /// The user's password.
        /// </summary>
        [Required]
        public string Password { get; set; }

       /// <summary>
       /// The user's first name (can be null)
       /// </summary>
       [MaxLength(50)]
       [DisplayFormat(ConvertEmptyStringToNull = false)]
       [Required(AllowEmptyStrings = true)]
       public string FirstName { get; set; }

        /// <summary>
        /// The user's last name (can be null)
        /// </summary>
        [MaxLength(50)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        public string LastName { get; set; }

        /// <summary>
        /// The user's salt.
        /// </summary>
        [Required]
        public string Salt { get; set; }

        /// <summary>
        /// The user's role.
        /// </summary>
        public string Role { get; set; }
    }
}
