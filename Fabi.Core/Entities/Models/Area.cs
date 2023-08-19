using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class Area
{
    public int AreaId { get; set; }

    public int CountyId { get; set; }

    public string AreaName { get; set; } = null!;
}
