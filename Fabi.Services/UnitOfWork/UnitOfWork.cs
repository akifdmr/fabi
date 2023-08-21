using AutoMapper;
using Fabi.Core;
using Fabi.Core.Entities.Models;
using Fabi.Core.Interfaces;
using Fabi.EF.Data;
using Fabi.EF.Repositories;
using Microsoft.AspNetCore.Identity;

public class UnitOfWork : IUnitOfWork
{
    //The only place can access database 
    private readonly ApplicationDbContext _db;

    public UnitOfWork(ApplicationDbContext db,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        ITokenHandler jwt, IMapper mapper)
    {
        _db = db;

        //Initialize App Repositories
        //User = new BaseRepository<Users>(_db.Set<Users>());
        Auth = new AuthRepository(userManager, roleManager, jwt, mapper);
    }

    //public IBaseRepository<Users> User { get; private set; }
    public IAuthRepository Auth { get; private set; }

    public void Save() => _db.SaveChanges();
}
