using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class City
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Code { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<DeliveryGroup> DeliveryGroups { get; set; } = new List<DeliveryGroup>();

    public virtual ICollection<OrderDeliveryGroup> OrderDeliveryGroups { get; set; } = new List<OrderDeliveryGroup>();
}
