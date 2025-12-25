using Food.Core.Domain.Model.Emtities;
using Microsoft.EntityFrameworkCore;

namespace Food.Infra.Data.Db.SqlServer.Database
{
    public class AppFoodDbContext : DbContext
    {
        public AppFoodDbContext(DbContextOptions<AppFoodDbContext> options)
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