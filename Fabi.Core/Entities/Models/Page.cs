using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class Page
{
    public Guid Id { get; set; }

    public Guid PageCategoryId { get; set; }

    public string PageName { get; set; } = null!;
}
