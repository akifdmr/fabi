﻿using System;
using System.Collections.Generic;

namespace Fabi.Core.Entity;

public partial class OrderDeliveryGroup
{
    public Guid Id { get; set; }

    public Guid CityId { get; set; }

    public string Name { get; set; } = null!;

    public virtual City1 City { get; set; } = null!;

    public virtual ICollection<OrderDelivery> OrderDeliveries { get; set; } = new List<OrderDelivery>();
}
