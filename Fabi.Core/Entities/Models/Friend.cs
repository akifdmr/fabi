using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class Friend
{
    public Guid Id { get; set; }

    public DateTime BeFriendAt { get; set; }

    public Guid UserRefId { get; set; }

    public Guid? UserId { get; set; }

    public virtual User? User { get; set; }
}
