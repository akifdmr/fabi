using System;
using System.Collections.Generic;

namespace Fabi.Core.Entity;

public partial class User
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string SurName { get; set; } = null!;

    public Guid AddressId { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int CompanyId { get; set; }

    public Guid UserRoleId { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();

    public virtual ICollection<CompanyShowRoom> CompanyShowRooms { get; set; } = new List<CompanyShowRoom>();

    public virtual ICollection<CompanyUser> CompanyUsers { get; set; } = new List<CompanyUser>();

    public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; } = new List<EmployeeRole>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Friend> Friends { get; set; } = new List<Friend>();
}
