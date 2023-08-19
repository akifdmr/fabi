using System;
using System.Collections.Generic;

namespace Fabi.Core.Entity;

public partial class OrderDeliveryCompany
{
    public Guid Id { get; set; }

    public Guid OrderDeliveryId { get; set; }

    public Guid CompanyId { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual OrderDelivery OrderDelivery { get; set; } = null!;

    public virtual ICollection<OrderDeliveryCompanyProduct> OrderDeliveryCompanyProducts { get; set; } = new List<OrderDeliveryCompanyProduct>();
}
