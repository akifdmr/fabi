using System;
using System.Collections.Generic;

namespace Fabi.Core.Entity;

public partial class Price
{
    public Guid Id { get; set; }

    public Guid? ProductId { get; set; }

    public Guid? ProductPartId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal Amount { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IdActive { get; set; }
}
