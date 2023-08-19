using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class Town
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid CityId { get; set; }

    public int? Code { get; set; }

    public int? CityCode { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}
