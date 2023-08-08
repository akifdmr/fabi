global using Fabi.Core.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Fabi.EF;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
    {
    }

    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Fabi { get; set; }
}