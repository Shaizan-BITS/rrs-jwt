using System.ComponentModel.DataAnnotations;

namespace RRS.JWTLoginAuthenticationAuthorization.Api.Model
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string Role { get; set; } 
    }
}
