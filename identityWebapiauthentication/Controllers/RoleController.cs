using identityWebapiauthentication.Model;
using identityWebapiauthentication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace identityWebapiauthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServices roleServices;

        public RoleController(IRoleServices roleServices) 
        {
            this.roleServices = roleServices;
        }

        [Authorize(Roles = "admin")]
        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {

            var list = await this.roleServices.GetRolesAsync();
            return Ok(list);
        }

        [Authorize]
        [HttpGet("GetUserRole")]
        public async Task<IActionResult> GetuserRole(string userEmail)
        {
            var userClaims = await this.roleServices.GetUserRolesAsync(userEmail);
            return Ok(userClaims);

        }

        [Authorize(Roles = "admin")]
        [HttpPost("addRoles")]
        public async Task<ActionResult> AddRole(string[] roles)
        {
            var userrole = await this.roleServices.AddRolesAsync(roles);
            if (userrole.Count == 0)
            {
                return BadRequest();
            }
            return Ok(userrole);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("addUserRoles")]
        public async Task<ActionResult> AddUserRole([FromBody] AddUserModel addUser)
        {
            var result = await this.roleServices.AddUserRoleAsync(addUser.UserEmail, addUser.Roles);

            if (!result)
            {
                return BadRequest();
            }

            return StatusCode((int)HttpStatusCode.Created, result);
        }

    }
}
    

