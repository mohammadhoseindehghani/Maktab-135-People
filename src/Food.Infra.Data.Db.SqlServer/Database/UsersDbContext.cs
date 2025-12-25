using Food.Infra.Data.Db.SqlServer.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Food.Infra.Data.Db.SqlServer.Database;

public class UsersDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
{
    public UsersDbContext(DbContextOptions<UsersDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
	    base.OnModelCreating(builder);
	    builder.HasDefaultSchema("Users");
    }
}