using System;
using System.Collections.Generic;

namespace Fabi.Core.Entity;

public partial class AccountRole
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
