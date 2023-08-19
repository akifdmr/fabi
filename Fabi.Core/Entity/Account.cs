using System;
using System.Collections.Generic;

namespace Fabi.Core.Entity;

public partial class Account
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public Guid AccountRoleId { get; set; }

    public bool? IdActive { get; set; }

    public virtual AccountPermissionPageCategory? AccountPermissionPageCategory { get; set; }

    public virtual AccountRole AccountRole { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User User { get; set; } = null!;
}
