using Microsoft.AspNetCore.Identity;
using Fabi.Core.Entities.Models;
using Fabi.Core.Interfaces;
using Fabi.EF;
using Fabi.EF.Repositories;
using AutoMapper;

namespace Fabi.Services.UOW;

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
        Genre = new BaseRepository<Genre>(_db.Set<Genre>());
        Movie = new BaseRepository<Movie>(_db.Set<Movie>());
        Auth = new AuthRepository(userManager, roleManager, jwt, mapper);
    }

    public IBaseRepository<Genre> Genre { get; private set; }
    public IBaseRepository<Movie> Movie { get; private set; }
    public IAuthRepository Auth { get; private set; }

    public void Save() => _db.SaveChanges();
}
