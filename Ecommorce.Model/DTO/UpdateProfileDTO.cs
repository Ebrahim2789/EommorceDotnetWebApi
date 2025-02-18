﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.DTO
{
    internal class UpdateProfileDTO
    {
        [MaxLength(50, ErrorMessage = "First name must be less than or equal to 50 characters.")]
        public required string Firstname { get; set; }
        [MaxLength(50, ErrorMessage = "Last name must be less than or equal to 50 characters.")]
        public required string Lastname { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [MaxLength(100, ErrorMessage = "Email must be less than or equal to 100 characters.")]
        public required string Email { get; set; }
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        [MaxLength(100, ErrorMessage = "Password must be less than or equal to 100 characters.")]
        public required string Password { get; set; }
    }
}
