using System;
using System.Collections.Generic;

namespace Fabi.Core.Entity;

public partial class City
{
    public int CityId { get; set; }

    public int CountryId { get; set; }

    public string CityName { get; set; } = null!;

    public string PlateNo { get; set; } = null!;

    public string PhoneCode { get; set; } = null!;
}
