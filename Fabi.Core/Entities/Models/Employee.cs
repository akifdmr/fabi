using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class Employee
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid UserRoleId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual ICollection<OrderDelivery> OrderDeliveries { get; set; } = new List<OrderDelivery>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual User User { get; set; } = null!;

    public virtual UserRole UserRole { get; set; } = null!;
}
