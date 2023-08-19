using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class ApartDaire
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string KiraciAdı { get; set; } = null!;

    public string KiracıSoyadi { get; set; } = null!;

    public string KiraciTelefon { get; set; } = null!;

    public decimal KiraBedeli { get; set; }

    public DateTime? KiraciGiris { get; set; }

    public DateTime? KiraciCikis { get; set; }

    public bool? IsActive { get; set; }
}
