using System.ComponentModel.DataAnnotations;

namespace RRS.JWTLoginAuthenticationAuthorization.Api.Models
{
    public class UserRegistrationDto
    {
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
