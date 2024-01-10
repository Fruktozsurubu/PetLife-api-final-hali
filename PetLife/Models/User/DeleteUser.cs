using System.ComponentModel.DataAnnotations;

namespace Models.User
{
    public class DeleteUser
    {

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        

    }
}
