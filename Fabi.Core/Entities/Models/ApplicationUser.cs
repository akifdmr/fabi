using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public  class ApplicationUser : IdentityUser
{

    public Guid UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public Guid AccountRoleId { get; set; }

    public bool? IdActive { get; set; }

    public virtual AccountPermissionPageCategory? AccountPermissionPageCategory { get; set; }

    public virtual AccountRole AccountRole { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Users User { get; set; } = null!;

    public List<RefreshToken>? RefreshTokens { get; set; }

}
