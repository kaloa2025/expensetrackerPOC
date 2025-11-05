using expenseTrackerPOC.Data.Dtos;
using expenseTrackerPOC.Models;
using System.Security.Claims;

namespace expenseTrackerPOC.Services.Auth.Interfaces
{
    public interface IJwtService
    {
        Task<(string accessToken, string refreshToken)> GenerateTokenAsync(UserDto user);
        ClaimsPrincipal ValidateToken(string token);
        Task<string> RefreshTokenAsync(string refreshToken);

    }
}
