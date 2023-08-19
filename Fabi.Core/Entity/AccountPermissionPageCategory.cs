using System;
using System.Collections.Generic;

namespace Fabi.Core.Entity;

public partial class AccountPermissionPageCategory
{
    public Guid Id { get; set; }

    public Guid PageCategoryId { get; set; }

    public Guid AccountId { get; set; }

    public virtual Account IdNavigation { get; set; } = null!;

    public virtual PageCategory PageCategory { get; set; } = null!;
}
