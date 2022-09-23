using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsEvents.API.Models;
using StudentsEvents.API.Services;
using System.Data;
using System.Security.Claims;

namespace StudentsEvents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManaging _userManaging;
        private readonly IConfiguration _configuration;

        public UsersController(IUserManaging userManaging,
            IConfiguration configuration)
        {
            _userManaging = userManaging;
            _configuration = configuration;
        }
        [HttpGet("GetUsers")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get()
        {
            var data = await (FirebaseAuth.DefaultInstance.ListUsersAsync(new ListUsersOptions()).ReadPageAsync(200));
            return Ok(data);
        }

        [HttpPost("SetAsAdmin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SetAsAdmin([FromBody]string uid)
        {
            var claims = new Dictionary<string, object>();

            //foreach (var item in await _userManaging.GetRoles(uid))
            //{
            //    claims.Add(ClaimTypes.Role, item.Name);
            //}
            claims.Add(ClaimTypes.Role, "Admin");

            await FirebaseAuth.DefaultInstance.SetCustomUserClaimsAsync(uid, claims);

            return Ok();
        }
        [HttpPost("RemoveRoles")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveRoles([FromBody] string uid)
        {
            var claims = new Dictionary<string, object>();

            claims.Add(ClaimTypes.Role, null);

            await FirebaseAuth.DefaultInstance.SetCustomUserClaimsAsync(uid, claims);

            return Ok();
        }
    }
}
