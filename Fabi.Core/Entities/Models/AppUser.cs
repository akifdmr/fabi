using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class AppUser
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public Guid CompanyId { get; set; }

    public Guid AddressId { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? PasswordHash { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;
}
