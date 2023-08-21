using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class ApplicationUser : IdentityUser
{
    public Guid Id { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? PasswordHash { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public Guid? CompanyId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public Guid? AddressId { get; set; }

    public virtual ICollection<AccountRoleRelation> AccountRoleRelations { get; set; } = new List<AccountRoleRelation>();

    public virtual Address? Address { get; set; }

    public virtual Company? Company { get; set; }

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}
