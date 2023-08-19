using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class OrderDeliveryCompanyProduct
{
    public Guid Id { get; set; }

    public Guid OrderDeliveryCompanyId { get; set; }

    public Guid OrderProductId { get; set; }

    public virtual OrderDeliveryCompany OrderDeliveryCompany { get; set; } = null!;

    public virtual OrderProduct OrderProduct { get; set; } = null!;
}
