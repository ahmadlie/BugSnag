using Bugsnag;
using Business.Abstract;
using DataAccess;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugSnagUsing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IClient _bugsnag;
        private IUserService _userService;

        public UserController(IUserService userService, IClient client)
        {
            _userService = userService;
            _bugsnag = client;
        }


        [HttpPost("/SignUp")]
        public IActionResult SignUp([FromBody] UserDTO userDTO)
        {
            try
            {
                _userService.SignUp(userDTO);

            }
            catch (Exception ex)
            {
                _bugsnag.Notify(ex);
                return BadRequest(ex.Message);
            }

            return Ok("User Saccesfully Created");
        }


        [HttpPost("/Login")]
        public IActionResult LogIn([FromBody] UserDTO userDTO)
        {
            try
            {
                _userService.Login(userDTO);
            }
            catch (Exception ex)
            {
                
                _bugsnag.Notify(ex);
                return BadRequest(ex.Message);
            }

            return Ok("Saccesfully Login");
        }

    }
}
