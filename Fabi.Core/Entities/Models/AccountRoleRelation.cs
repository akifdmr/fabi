using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class AccountRoleRelation
{
    public Guid Id { get; set; }

    public Guid AccountId { get; set; }

    public Guid RoleId { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ApplicationUser Account { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
