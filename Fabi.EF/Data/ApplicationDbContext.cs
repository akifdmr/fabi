using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Fabi.Core;
using Fabi.Core.Entities.Models;

namespace Fabi.EF.Data;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    //public DbSet<Users> Users { get; set; }
}
