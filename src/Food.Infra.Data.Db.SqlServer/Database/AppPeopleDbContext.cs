using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UI_MVC.Models.Entities;

namespace UI_MVC.Models.Database
{
    public class AppPeopleDbContext : IdentityDbContext
    {
        public AppPeopleDbContext(DbContextOptions<AppPeopleDbContext> options) : base(options)
        {
        }
        
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
