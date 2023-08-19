using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabi.Core.DTOs.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
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
}
