using Fabi.Core.Entities.Models;
using System.IdentityModel.Tokens.Jwt;

namespace Fabi.Core.Interfaces;
public interface ITokenHandler
{
    Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user);
    Task<RefreshToken> CreateRefreshToken(ApplicationUser user);
}
