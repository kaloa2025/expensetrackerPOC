using expenseTrackerPOC.Data.Dtos;
using expenseTrackerPOC.Models;
using expenseTrackerPOC.Services.Auth.Interfaces;
using System.Security.Claims;

namespace expenseTrackerPOC.Services.Auth
{
    public class JwtService : IJwtService
    {
        public Task<(string accessToken, string refreshToken)> GenerateTokenAsync(UserDto user)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.Role, user.Role),
                new("userId", user.Id.ToString()),
                new("sessionId", Guid.NewGuid().ToString()), // For session tracking
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            };

            var accessToken = GenerateJwtToken(claims, TimeSpan.FromMinutes(30));
            var refreshToken = await GenerateRefreshTokenAsync(user.Id);
            
            return (accessToken, refreshToken);
        }

        public string GenerateJwtToken(IEnumerable<Claim> claims, TimeSpan expiry)
        {
            var key = ;
            var creds = new SigningCredentials(key, SecutityAlgorithms.HmaSha256);
            var token = new JwtSecurityToken(
                issuer :
                audience :
                claims : claims
                expires : DateTime.UtcNow.Add(expiry)
                singingCredentials :creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> GenerateRefreshToken(int  userId)
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                UserId = userId,
                ExpiryDate = DateTime.UtcNow.AddDays(30),
                CreatedDate = DateTime.UtcNow
            }
            await _userService.SaveRefreshTokenAsync(refreshToken);
            return refreshToken.Token;
        }

        public Task<string> RefreshTokenAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public ClaimsPrincipal ValidateToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
