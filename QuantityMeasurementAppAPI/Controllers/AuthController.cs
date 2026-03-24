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
            var response = _userService.Login(loginDto);

            if (!response.Success)
            {
                return Unauthorized(response);
            }

            return Ok(response);
        }

        [HttpGet("google-login")]
        [AllowAnonymous]
        public async Task<IActionResult> GoogleLogin([FromQuery] GoogleLoginDto googleLoginDto)
        {
            if (googleLoginDto == null || string.IsNullOrWhiteSpace(googleLoginDto.IdToken))
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = "IdToken is required"
                });
            }

            var response = await _userService.GoogleLoginAsync(googleLoginDto);

            if (!response.Success)
            {
                return Unauthorized(response);
            }

            return Ok(response);
        }

        [HttpGet("me")]
        [Authorize]
        public IActionResult GetCurrentUser()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var name = User.FindFirst(ClaimTypes.Name)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return Ok(new
            {
                Success = true,
                Message = "Current user fetched successfully",
                Data = new
                {
                    UserId = userId,
                    FullName = name,
                    Email = email,
                    Role = role
                }
            });
        }
    }
}