using System;
using System.Collections.Generic;

namespace Fabi.Core.Entity;

public partial class CompanyShowRoom
{
    public Guid Id { get; set; }

    public Guid CompanyId { get; set; }

    public Guid AddressId { get; set; }

    public Guid ContactUserId { get; set; }

    public bool? IsActive { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;

    public virtual User ContactUser { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
