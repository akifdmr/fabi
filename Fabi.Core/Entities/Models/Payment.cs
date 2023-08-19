using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class Payment
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }

    public Guid CompanyId { get; set; }

    public Guid CompanyUserId { get; set; }

    public Guid PaymentTypeId { get; set; }

    public Guid EmployeeId { get; set; }

    public decimal Amount { get; set; }

    public byte[] PaymentDate { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual CompanyUser CompanyUser { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
