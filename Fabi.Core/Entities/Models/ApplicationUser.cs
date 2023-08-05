using Microsoft.AspNetCore.Identity;

namespace Fabi.Core.Entities.Models;
public class ApplicationUser : IdentityUser
{
    [MaxLength(50)]
    public string FirstName { get; set; }

    [MaxLength(50)]
    public string LastName { get; set; }

    public List<RefreshToken>? RefreshTokens { get; set; }
}
