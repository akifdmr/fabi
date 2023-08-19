using System;
using System.Collections.Generic;

namespace Fabi.Core.Entity;

public partial class ProductPart
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public string Name { get; set; } = null!;

    public int ProductPartCount { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual Product Product { get; set; } = null!;
}
