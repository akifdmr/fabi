using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class Order
{
    public Guid Id { get; set; }

    public Guid CompanyId { get; set; }

    public Guid CompanyUserId { get; set; }

    public Guid EmployeeId { get; set; }

    public Guid CompanyShowRoomId { get; set; }

    public byte[] OrderDate { get; set; } = null!;

    public DateTime DeliveryDate { get; set; }

    public decimal Amount { get; set; }

    public decimal Discount { get; set; }

    public decimal Balance { get; set; }

    public Guid DiscountBy { get; set; }

    public Guid? OrderStatusId { get; set; }

    public Guid? ConfirmedBy { get; set; }

    public DateTime? OrderComplateDate { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual CompanyShowRoom CompanyShowRoom { get; set; } = null!;

    public virtual CompanyUser CompanyUser { get; set; } = null!;

    public virtual ApplicationUser? ConfirmedByNavigation { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual OrderStatus? OrderStatus { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
