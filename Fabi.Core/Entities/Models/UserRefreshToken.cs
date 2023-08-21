using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class UserRefreshToken
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string? RefreshToken { get; set; }

    public bool? IsActive { get; set; }
}
