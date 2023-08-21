using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class RefreshToken
{
    public string? Token { get; set; }

    public Guid? ApplicationUserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ExpiredDate { get; set; }

    public DateTime? RevokedDate { get; set; }

    public bool? IsExpired { get; set; }

    public bool? IsActive { get; set; }

    public Guid Id { get; set; }

    public virtual ApplicationUser? ApplicationUser { get; set; }
}
