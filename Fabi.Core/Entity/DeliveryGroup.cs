using System;
using System.Collections.Generic;

namespace Fabi.Core.Entity;

public partial class DeliveryGroup
{
    public Guid Id { get; set; }

    public Guid Name { get; set; }

    public Guid CityId { get; set; }

    public virtual City1 City { get; set; } = null!;

    public virtual ICollection<DeliveryGroupCompany> DeliveryGroupCompanies { get; set; } = new List<DeliveryGroupCompany>();
}
