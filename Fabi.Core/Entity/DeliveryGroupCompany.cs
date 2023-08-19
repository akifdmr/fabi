using System;
using System.Collections.Generic;

namespace Fabi.Core.Entity;

public partial class DeliveryGroupCompany
{
    public Guid Id { get; set; }

    public Guid DeliveryGroupId { get; set; }

    public Guid CompanyId { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual DeliveryGroup DeliveryGroup { get; set; } = null!;
}
