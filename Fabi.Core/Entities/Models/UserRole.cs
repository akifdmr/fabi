using System;
using System.Collections.Generic;

namespace Fabi.Core.Entities.Models;

public partial class UserRole
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsCompanyRole { get; set; }

    public bool IsEmployeeRole { get; set; }

    public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; } = new List<EmployeeRole>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
