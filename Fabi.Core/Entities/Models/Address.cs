using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class Address
{
    public Guid Id { get; set; }

    public Guid CityId { get; set; }

    public Guid TownId { get; set; }

    public string AddressDetail { get; set; } = null!;

    public Guid AddressTypeId { get; set; }

    public string? CoordinatesX { get; set; }

    public string? CoordinatesY { get; set; }

    public virtual AddressType AddressType { get; set; } = null!;

    public virtual City1 City { get; set; } = null!;

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();

    public virtual ICollection<CompanyShowRoom> CompanyShowRooms { get; set; } = new List<CompanyShowRoom>();

    public virtual Town Town { get; set; } = null!;

    public virtual ICollection<Users> Users { get; set; } = new List<Users>();
}
