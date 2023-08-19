using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class OrderStatus
{
    public Guid Id { get; set; }

    public string OrderStatusName { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
