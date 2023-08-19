using System;
using System.Collections.Generic;

namespace Fabi.Core.Entity;

public partial class AddressType
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}
