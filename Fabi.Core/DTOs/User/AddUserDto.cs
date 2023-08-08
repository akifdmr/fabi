using System;
namespace Fabi.Core.DTOs.User;

public class AddUserDto
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public Guid CityId { get; set; }
    public Guid TownId { get; set; }
    public Guid NeighborhoodId { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public int CompanyId { get; set; }
    public Guid UserRoleId { get; set; }
}



