using QuantityMeasurementAppBusinessLayer.Helpers;
using QuantityMeasurementAppBusinessLayer.Interfaces;
using QuantityMeasurementAppModel.DTOs;
using QuantityMeasurementAppModel.Entities;
using QuantityMeasurementAppRepositoryLayer.Interfaces;

namespace QuantityMeasurementAppBusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordHelper _passwordHelper;
        private readonly JwtTokenHelper _jwtTokenHelper;
        private readonly GoogleTokenHelper _googleTokenHelper;

        public UserService(
            IUserRepository userRepository,
            PasswordHelper passwordHelper,
            JwtTokenHelper jwtTokenHelper,
            GoogleTokenHelper googleTokenHelper)
        {
            _userRepository = userRepository;
            _passwordHelper = passwordHelper;
            _jwtTokenHelper = jwtTokenHelper;
            _googleTokenHelper = googleTokenHelper;
        }

        public AuthResponseDto Register(RegisterDto registerDto)
        {
            var existingUser = _userRepository.GetUserByEmail(registerDto.Email);
            if (existingUser != null)
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Message = "User already exists"
                };
            }

            var user = new User
            {
                FullName = registerDto.FullName,
                Email = registerDto.Email,
                PasswordHash = _passwordHelper.HashPassword(registerDto.Password),
                Role = "User",
                IsGoogleUser = false,
                CreatedAt = DateTime.UtcNow
            };

            var savedUser = _userRepository.AddUser(user);
            var token = _jwtTokenHelper.GenerateToken(savedUser);

            return new AuthResponseDto
            {
                Success = true,
                Message = "Registration successful",
                Token = token,
                Email = savedUser.Email,
                FullName = savedUser.FullName,
                Role = savedUser.Role
            };
        }

        public AuthResponseDto Login(LoginDto loginDto)
        {
            var user = _userRepository.GetUserByEmail(loginDto.Email);
            if (user == null)
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Message = "Invalid email or password"
                };
            }

            var isValidPassword = _passwordHelper.VerifyPassword(loginDto.Password, user.PasswordHash);
            if (!isValidPassword)
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Message = "Invalid email or password"
                };
            }

            var token = _jwtTokenHelper.GenerateToken(user);

            return new AuthResponseDto
            {
                Success = true,
                Message = "Login successful",
                Token = token,
                Email = user.Email,
                FullName = user.FullName,
                Role = user.Role
            };
        }

        public async Task<AuthResponseDto> GoogleLoginAsync(GoogleLoginDto googleLoginDto)
        {
            var payload = await _googleTokenHelper.VerifyGoogleTokenAsync(googleLoginDto.IdToken);

            if (payload == null || string.IsNullOrWhiteSpace(payload.Email))
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Message = "Invalid Google token"
                };
            }

            var user = _userRepository.GetUserByEmail(payload.Email);

            if (user == null)
            {
                user = new User
                {
                    FullName = payload.Name ?? "Google User",
                    Email = payload.Email,
                    PasswordHash = string.Empty,
                    Role = "User",
                    IsGoogleUser = true,
                    CreatedAt = DateTime.UtcNow
                };

                user = _userRepository.AddUser(user);
            }

            var token = _jwtTokenHelper.GenerateToken(user);

            return new AuthResponseDto
            {
                Success = true,
                Message = "Google login successful",
                Token = token,
                Email = user.Email,
                FullName = user.FullName,
                Role = user.Role
            };
        }
    }
}