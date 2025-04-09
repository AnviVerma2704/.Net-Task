using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskDotNet.Entities.IdentityEntities;

namespace TaskDotNet.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser>? _userManager;
        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet("get-users")]
        [Authorize]
        public async Task<IActionResult> GetUsers()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var roles = await _userManager.GetRolesAsync(currentUser);

            bool isAdmin = roles.Contains("Admin");

            var users = _userManager.Users.ToList();

            var result = new List<object>();

            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                if (isAdmin || userRoles.Contains("Employee"))
                {
                    result.Add(new
                    {
                        user.Id,
                        user.UserName,
                        user.Email,
                        Roles = userRoles
                    });
                }
            }

            return Ok(result);
        }

    }
}
