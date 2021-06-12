using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;
        IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var user = _authService.Login(userForLoginDto);
            if (!user.Success)
            {
                return BadRequest(user);
            }

            var result = _authService.CreateAccessToken(user.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("register")]
        public IActionResult Result(UserForRegisterDto userForRegisterDto)
        {
            var userCheck = _authService.UserExists(userForRegisterDto.Email);

            if (!userCheck.Success)
            {
                return BadRequest(userCheck);
            }

            var registeredUser = _authService.Register(userForRegisterDto);
            var result = _authService.CreateAccessToken(registeredUser.Data);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getUserByEmail")]
        public IActionResult GetUserByEmail(string email)
        {
            var result = _userService.GetUserByEmail(email);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("getUserClaims")]
        public IActionResult GetUserClaims(User user)
        {
            var result = _userService.GetClaims(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
