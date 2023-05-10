using CDSiteUsers.Data;
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
        private readonly StoreAPIDbContext _dbContext;

        public UserController(StoreAPIDbContext dbContext) => _dbContext = dbContext;

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
            var userItems = GetUserItems(currentUser);

            return Ok($"Welcome to your seller portal, {currentUser?.GivenName}. First Item: {userItems?[0] }");
        }

        private UserModel? GetCurrentUser()
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

        private List<CDModel> GetUserItems(UserModel user)
        {
            var items = _dbContext.CDs.Where(x => x.SellerUsername == user.Id);

            return items.ToList();
        }
    }
}
