using System;
using System.Collections.Generic;

namespace Fabi.Core.Entity;

public partial class Neighborhood
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid TownId { get; set; }

    public string? Xcoordinate { get; set; }

    public string? Ycoordinate { get; set; }

    public int? TownCode { get; set; }

    public int? Code { get; set; }

    public string? XcoordinateMax { get; set; }

    public string? YcoordinateMax { get; set; }
}
