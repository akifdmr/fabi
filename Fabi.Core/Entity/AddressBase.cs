using System;
using System.Collections.Generic;

namespace Fabi.Core.Entity;

public partial class AddressBase
{
    public int Id { get; set; }

    public string? Text { get; set; }

    public int? ParentId { get; set; }

    public string? Minlongitude { get; set; }

    public string? Minlatitude { get; set; }

    public string? Maxlongitude { get; set; }

    public string? Maxlatitude { get; set; }

    public int? NeighbourhoodId { get; set; }

    public Guid? AddressId { get; set; }
}
