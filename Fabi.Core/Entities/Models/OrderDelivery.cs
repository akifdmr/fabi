using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class OrderDelivery
{
    public Guid Id { get; set; }

    public Guid OrderDeliveryGroupId { get; set; }

    public byte[] PlanedDate { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string Status { get; set; } = null!;

    public Guid EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<OrderDeliveryCompany> OrderDeliveryCompanies { get; set; } = new List<OrderDeliveryCompany>();

    public virtual OrderDeliveryGroup OrderDeliveryGroup { get; set; } = null!;
}
