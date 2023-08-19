using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class OrderProduct
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }

    public Guid ProductId { get; set; }

    public Guid ProductPartId { get; set; }

    public string? ProductDetail { get; set; }

    public string? Color { get; set; }

    public int Counts { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal Discount { get; set; }

    public bool? IsDelivered { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual ICollection<OrderDeliveryCompanyProduct> OrderDeliveryCompanyProducts { get; set; } = new List<OrderDeliveryCompanyProduct>();

    public virtual Product Product { get; set; } = null!;

    public virtual ProductPart ProductPart { get; set; } = null!;
}
