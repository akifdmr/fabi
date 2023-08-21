using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class CompanyUser
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid CompanyId { get; set; }

    public bool? IsActive { get; set; }

    public bool? UserRoleId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual User User { get; set; } = null!;
}
