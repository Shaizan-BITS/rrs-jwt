using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RRS.JWTLoginAuthenticationAuthorization.Api.Database;
using RRS.JWTLoginAuthenticationAuthorization.Api.Dto;
using RRS.JWTLoginAuthenticationAuthorization.Api.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RRS.JWTLoginAuthenticationAuthorization.Api.Controllers
{
    [Route("rrs/jwt/api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext applicationDbContext;

        public LoginController(IConfiguration config, ApplicationDbContext applicationDbContext)
        {
            _config = config;
            this.applicationDbContext = applicationDbContext;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
        {
            var user = await applicationDbContext.Users
                                     .SingleOrDefaultAsync(u => u.Username == userLogin.Username);
            if (user == null)
            {
                return Unauthorized("User does not exist.");
            }

            var passwordIsValid = user.Password == userLogin.Password;
            if (!passwordIsValid)
            {
                return Unauthorized("Invalid password.");
            }

            if (user != null)
            {
                var token = GenerateToken(user);
                return Ok(new { access_token = token });
            }

            return NotFound("User not found");
        }

        // To generate token
        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Username),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(300),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
