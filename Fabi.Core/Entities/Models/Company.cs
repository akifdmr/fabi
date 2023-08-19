using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class Company
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid AddressId { get; set; }

    public string Phone { get; set; } = null!;

    public string Phone2 { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string TaxNumber { get; set; } = null!;

    public string TaxOffice { get; set; } = null!;

    public Guid StatusId { get; set; }

    public bool? IsActive { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<CompanyShowRoom> CompanyShowRooms { get; set; } = new List<CompanyShowRoom>();

    public virtual ICollection<DeliveryGroupCompany> DeliveryGroupCompanies { get; set; } = new List<DeliveryGroupCompany>();

    public virtual ICollection<OrderDeliveryCompany> OrderDeliveryCompanies { get; set; } = new List<OrderDeliveryCompany>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
