using System;
using System.Collections.Generic;

namespace Fabi.Core.Entity;

public partial class Status
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
}
