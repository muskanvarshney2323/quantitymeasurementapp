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

        public UserService(IUserRepository userRepository, PasswordHelper passwordHelper, JwtTokenHelper jwtTokenHelper)
        {
            _userRepository = userRepository;
            _passwordHelper = passwordHelper;
            _jwtTokenHelper = jwtTokenHelper;
        }

        public AuthResponseDto Register(RegisterDto registerDto)
        {
            try
            {
                if (registerDto == null)
                {
                    return new AuthResponseDto
                    {
                        Success = false,
                        Message = "Register request cannot be null"
                    };
                }

                if (string.IsNullOrWhiteSpace(registerDto.Name) ||
                    string.IsNullOrWhiteSpace(registerDto.Email) ||
                    string.IsNullOrWhiteSpace(registerDto.Password))
                {
                    return new AuthResponseDto
                    {
                        Success = false,
                        Message = "Name, email and password are required"
                    };
                }

                var existingUser = _userRepository.GetUserByEmail(registerDto.Email);

                if (existingUser != null)
                {
                    return new AuthResponseDto
                    {
                        Success = false,
                        Message = "User already exists with this email"
                    };
                }

                var user = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = registerDto.Name,
                    Email = registerDto.Email,
                    PasswordHash = _passwordHelper.HashPassword(registerDto.Password),
                    IsGoogleUser = false,
                    CreatedAt = DateTime.UtcNow
                };

                bool isRegistered = _userRepository.RegisterUser(user);

                if (!isRegistered)
                {
                    return new AuthResponseDto
                    {
                        Success = false,
                        Message = "User registration failed"
                    };
                }

                string token = _jwtTokenHelper.GenerateToken(user.Id, user.Name, user.Email);

                return new AuthResponseDto
                {
                    Success = true,
                    Message = "User registered successfully",
                    Token = token,
                    Email = user.Email,
                    Name = user.Name
                };
            }
            catch (Exception ex)
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Message = $"Exception occurred: {ex.Message}"
                };
            }
        }

        public AuthResponseDto Login(LoginDto loginDto)
        {
            try
            {
                if (loginDto == null)
                {
                    return new AuthResponseDto
                    {
                        Success = false,
                        Message = "Login request cannot be null"
                    };
                }

                if (string.IsNullOrWhiteSpace(loginDto.Email) ||
                    string.IsNullOrWhiteSpace(loginDto.Password))
                {
                    return new AuthResponseDto
                    {
                        Success = false,
                        Message = "Email and password are required"
                    };
                }

                var user = _userRepository.GetUserByEmail(loginDto.Email);

                if (user == null)
                {
                    return new AuthResponseDto
                    {
                        Success = false,
                        Message = "User not found"
                    };
                }

                if (user.IsGoogleUser)
                {
                    return new AuthResponseDto
                    {
                        Success = false,
                        Message = "This account is registered with Google login"
                    };
                }

                bool isPasswordValid = _passwordHelper.VerifyPassword(loginDto.Password, user.PasswordHash);

                if (!isPasswordValid)
                {
                    return new AuthResponseDto
                    {
                        Success = false,
                        Message = "Invalid password"
                    };
                }

                string token = _jwtTokenHelper.GenerateToken(user.Id, user.Name, user.Email);

                return new AuthResponseDto
                {
                    Success = true,
                    Message = "Login successful",
                    Token = token,
                    Email = user.Email,
                    Name = user.Name
                };
            }
            catch (Exception ex)
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Message = $"Exception occurred: {ex.Message}"
                };
            }
        }

        public AuthResponseDto GoogleLogin(GoogleLoginDto googleLoginDto)
        {
            try
            {
                if (googleLoginDto == null)
                {
                    return new AuthResponseDto
                    {
                        Success = false,
                        Message = "Google login request cannot be null"
                    };
                }

                if (string.IsNullOrWhiteSpace(googleLoginDto.Name) ||
                    string.IsNullOrWhiteSpace(googleLoginDto.Email))
                {
                    return new AuthResponseDto
                    {
                        Success = false,
                        Message = "Name and email are required for Google login"
                    };
                }

                var existingUser = _userRepository.GetUserByEmail(googleLoginDto.Email);

                User user;

                if (existingUser == null)
                {
                    user = new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = googleLoginDto.Name,
                        Email = googleLoginDto.Email,
                        PasswordHash = string.Empty,
                        IsGoogleUser = true,
                        CreatedAt = DateTime.UtcNow
                    };

                    bool isRegistered = _userRepository.RegisterUser(user);

                    if (!isRegistered)
                    {
                        return new AuthResponseDto
                        {
                            Success = false,
                            Message = "Google user registration failed"
                        };
                    }
                }
                else
                {
                    user = existingUser;
                }

                string token = _jwtTokenHelper.GenerateToken(user.Id, user.Name, user.Email);

                return new AuthResponseDto
                {
                    Success = true,
                    Message = "Google login successful",
                    Token = token,
                    Email = user.Email,
                    Name = user.Name
                };
            }
            catch (Exception ex)
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Message = $"Exception occurred: {ex.Message}"
                };
            }
        }
    }
}