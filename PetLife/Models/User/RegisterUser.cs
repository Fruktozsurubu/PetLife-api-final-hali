using System.ComponentModel.DataAnnotations;

namespace Models.User
{
    public class RegisterUser
    {
        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required]
        public string ProfileUrl { get; set; } = string.Empty;

        [Required,EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;

    }
}
