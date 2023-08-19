using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class CompanyPrePaid
{
    public Guid Id { get; set; }

    public Guid? CompanyId { get; set; }

    public Guid? PriceId { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal BalanceAmount { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IdActive { get; set; }
}
