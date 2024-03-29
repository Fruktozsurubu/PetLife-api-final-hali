﻿using System.ComponentModel.DataAnnotations;

namespace Models.User
{
    public class LoginUser
    {
        
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;

    }
}
