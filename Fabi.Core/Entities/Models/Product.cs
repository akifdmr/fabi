using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Color { get; set; } = null!;

    public int ProductPartCount { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual ICollection<ProductPart> ProductParts { get; set; } = new List<ProductPart>();
}
