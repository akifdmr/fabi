using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class Country
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
}
