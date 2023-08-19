using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class AccountPermissionPageCategory
{
    public Guid Id { get; set; }

    public Guid PageCategoryId { get; set; }

    public Guid AccountId { get; set; }

    public virtual ApplicationUser IdNavigation { get; set; } = null!;

    public virtual PageCategory PageCategory { get; set; } = null!;
}
