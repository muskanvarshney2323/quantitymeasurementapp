using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuantityMeasurementAppBusinessLayer.Interfaces;
using QuantityMeasurementAppModel.DTOs;
using System.Security.Claims;

namespace QuantityMeasurementAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] RegisterDto registerDto)
        {
            if (registerDto == null)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = "Request body cannot be null"
                });
            }

            var response = _userService.Register(registerDto);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            if (loginDto == null)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = "Request body cannot be null"
                });
            }

            var response = _userService.Login(loginDto);

            if (!response.Success)
            {
                return Unauthorized(response);
            }

            return Ok(response);
        }

        [HttpPost("google-login")]
        [AllowAnonymous]
        public IActionResult GoogleLogin([FromBody] GoogleLoginDto googleLoginDto)
        {
            if (googleLoginDto == null)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = "Request body cannot be null"
                });
            }

            var response = _userService.GoogleLogin(googleLoginDto);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("me")]
        [Authorize]
        public IActionResult GetCurrentUser()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var name = User.FindFirst(ClaimTypes.Name)?.Value;

            return Ok(new
            {
                Success = true,
                Message = "Current user fetched successfully",
                Email = email,
                Name = name
            });
        }
    }
}