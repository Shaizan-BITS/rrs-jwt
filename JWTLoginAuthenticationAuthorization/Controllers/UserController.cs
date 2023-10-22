using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RRS.JWTLoginAuthenticationAuthorization.Api.Models;
using System.Security.Claims;

namespace RRS.JWTLoginAuthenticationAuthorization.Api.Controllers
{
    [Route("rrs/jwt/api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //For admin Only
        [HttpGet]
        [Route("auth/admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminEndPoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi you are an {currentUser.Role}");
        }

        //For end user only
        [HttpGet]
        [Route("auth")]
        [Authorize(Roles = "Admin, EndUser")]
        public IActionResult EndUserEndPoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi you are an {currentUser.Role}");
        }

        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new UserModel
                {
                    Username = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                    Role = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;

        }
    }
}
