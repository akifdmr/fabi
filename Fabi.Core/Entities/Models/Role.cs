using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class Role
{
    public Guid Id { get; set; }

    public Guid Name { get; set; }

    public bool IsEmployee { get; set; }

    public virtual ICollection<AccountRoleRelation> AccountRoleRelations { get; set; } = new List<AccountRoleRelation>();
}
