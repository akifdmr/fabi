using System;
using System.Collections.Generic;

namespace Fabi.Core.Entity;

public partial class PageCategory
{
    public Guid Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<AccountPermissionPageCategory> AccountPermissionPageCategories { get; set; } = new List<AccountPermissionPageCategory>();
}
