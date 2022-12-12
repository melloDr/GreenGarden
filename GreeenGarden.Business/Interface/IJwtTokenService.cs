using GreeenGarden.Data.Entities;
using System.Security.Claims;

namespace GreeenGarden.Business.Interface
{
    public interface IJwtTokenService
    {
        string GenerateTokenUser(Customer account);
        Task<string> GenerateTokenDMSAsync(Customer account);
        string GenerateToken(params Claim[] claims);
    }
}
