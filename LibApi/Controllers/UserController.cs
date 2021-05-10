using LibApi.Models;
using LibApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
        {
            _userService.RegisterUser(dto);

            return Ok();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto dto)
        {
            string token = _userService.GenerateJwtToken(dto);

            return Ok(token);
        }




    }
}
