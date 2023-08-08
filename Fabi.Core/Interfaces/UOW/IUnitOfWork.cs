using Fabi.Core.appsettings;
using Fabi.Core.Entities.Models;

namespace Fabi.Core.Interfaces;
public interface IUnitOfWork
{
    //Register App Repositories
   IBaseRepository<Genre> Genre { get; }
   IBaseRepository<Movie> Movie { get; }
    IAuthRepository Auth { get;  }

    //Global Methods
    void Save();
}
