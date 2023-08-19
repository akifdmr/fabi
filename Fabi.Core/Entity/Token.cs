using System;
using System.Collections.Generic;

namespace Fabi.Core.Entity;

public partial class Token
{
    public Guid Id { get; set; }

    public string? AccessToken { get; set; }

    public string? RefreshToken { get; set; }
}
