using System.Security.Claims;

namespace ERP.Application.Interface.Logic;
public interface IJWTManager
{
    bool VerifyToken(string token);
    ClaimsPrincipal GetPrincipalFromToken(string token);
    Task<string> GenerateAccessTokenAsync(string userName);
    Task<string> GenerateRefreshTokenAsync(string userName);
}
