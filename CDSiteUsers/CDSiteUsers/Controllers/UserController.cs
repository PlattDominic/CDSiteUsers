using CDSiteUsers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CDSiteUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult Public()
        {
            return Ok("Welcome to the CD Store!!");
        }

        [HttpGet("mystore")]
        [Authorize(Roles = "seller")]
        public IActionResult SellerEndpoint()
        {
            var currentUser = GetCurrentUser();

            return Ok($"Welcome to your seller portal, {currentUser.GivenName}");
        }

        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null)
                return null;

            var userClaims = identity.Claims;

            return new UserModel
            {
                Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier).Value,
                Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email).Value,
                GivenName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName).Value,
                Surname = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname).Value,
                Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role).Value,
            };
        }
    }
}
