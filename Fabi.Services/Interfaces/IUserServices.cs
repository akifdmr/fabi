using Fabi.Core.DTOs.Common;
using Fabi.Core.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabi.Services.Interfaces;

public interface IUserServices
{
    List<UserDto> GetUsers();
    PaginatedDto<UserDto> GetPaginatedUsers(int pageNumber, int pageSize);
    UserDto GetUser(Guid id);
    UserDto Create(UserDto model);
    bool Update(UserDto model);
    bool Delete(Guid id);
}

