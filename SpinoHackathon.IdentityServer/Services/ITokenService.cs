using System.Security.Claims;

namespace SpinoHackathon.IdentityServer.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(string userName, string email);
        ClaimsPrincipal ValidateToken(string Token);
        string GetUserNameFromToken(string token);
    }
}
