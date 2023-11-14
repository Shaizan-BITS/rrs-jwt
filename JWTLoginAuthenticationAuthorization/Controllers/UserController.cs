using Microsoft.AspNetCore.Mvc;
using RRS.JWTLoginAuthenticationAuthorization.Api.Database;
using RRS.JWTLoginAuthenticationAuthorization.Api.Model;
using RRS.JWTLoginAuthenticationAuthorization.Api.Models;

namespace RRS.JWTLoginAuthenticationAuthorization.Api.Controllers
{
    [Route("rrs/api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserRegistrationDto registration)
        {
            // Check if the user already exists
            if (_context.Users.Any(u => u.Username == registration.Username))
            {
                return BadRequest("User already exists.");
            }

            // Create a new user object
            var user = new User
            {
                UserId = Guid.NewGuid(),
                Username = registration.Username,
                Email = registration.Email,
                Password = registration.Password,
                Role = "Passenger"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
