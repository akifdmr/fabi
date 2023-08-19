using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class AccountRole
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ApplicationUser> Accounts { get; set; } = new List<ApplicationUser>();
}
