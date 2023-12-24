using JWT_D.Models.DTOs;
using JWT_D.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT_D.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUser userService;
        public UsersController(IUser service)
        {
            userService = service;
        }

        //[Authorize(Roles = "Manager")]        <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterUserDTO data)
        {
            var user = await userService.Register(data, this.ModelState);

            if (ModelState.IsValid)
            {
                return user;
            }

            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO data)
        {
            var user = await userService.Authenticate(data.Username, data.Password);
            if (user != null)
            {
                return user;
            }
            return Unauthorized();
        }


        //[Authorize(Roles = "Admin")]
        [Authorize(Policy = "create")]
        [HttpGet("Profile")]
        public async Task<ActionResult<UserDTO>> Profile()
        {
            return await userService.GetUser(this.User); ;
        }
    }
}