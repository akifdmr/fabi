using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class EmployeeRole
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid UserRoleId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual Users User { get; set; } = null!;

    public virtual UserRole UserRole { get; set; } = null!;
}
