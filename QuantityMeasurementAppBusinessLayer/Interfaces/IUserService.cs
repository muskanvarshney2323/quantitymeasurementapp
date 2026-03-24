using QuantityMeasurementAppModel.DTOs;

namespace QuantityMeasurementAppBusinessLayer.Interfaces
{
    public interface IUserService
    {
        AuthResponseDto Register(RegisterDto registerDto);
        AuthResponseDto Login(LoginDto loginDto);
        Task<AuthResponseDto> GoogleLoginAsync(GoogleLoginDto googleLoginDto);
    }
}