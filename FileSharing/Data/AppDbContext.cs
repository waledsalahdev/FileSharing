using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FileSharing.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
       
                base.OnModelCreating(builder);
            SeedRoles(builder);
        }
        public DbSet<Uploads> Uploads  { get; set; }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
           (
                new IdentityRole() { Name="Admin",ConcurrencyStamp="1",NormalizedName="Admin"},
                new IdentityRole() { Name="User",ConcurrencyStamp="2",NormalizedName="User"}
           );
        }
    }
}
