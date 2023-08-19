using Fabi.Core.Entities.Models;

namespace Fabi.Core.Interfaces;
public interface IUnitOfWork
{
    //Register App Repositories
    //IBaseRepository<Users> User { get; }
    IAuthRepository Auth { get; }

    //Global Methods
    void Save();
}
