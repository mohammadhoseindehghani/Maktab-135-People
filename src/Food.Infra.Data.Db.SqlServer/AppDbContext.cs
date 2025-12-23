using Food.Core.Domain.Model.Emtities;
using Microsoft.EntityFrameworkCore;

namespace Food.Infra.Data.Db.SqlServer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }


        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
	        base.OnModelCreating(modelBuilder);
	        modelBuilder.Entity<Restaurant>().HasData(
		        new Restaurant
		        {
			        Name = "A",
			        Description = "B",
			        Id = 1
		        }
	        );
        }
    }
}