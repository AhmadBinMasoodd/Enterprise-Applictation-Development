using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UserManagementApi.Models
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "49145a4c-5cd6-4a8e-8f4f-2b51e6fb606d", Name = "Admin", NormalizedName = "Admin", ConcurrencyStamp = "3c8b96ee-0064-4613-ae94-99e334a1fea8" },
                new IdentityRole { Id = "f03e315e-bae9-4699-bf4a-962d833f6e8f", Name = "User", NormalizedName = "User", ConcurrencyStamp = "187481e9-a3be-481e-8ad4-7213aeaf84d0" },
                new IdentityRole { Id = "7e5ff430-700c-4dd0-a7c1-a8eab9626141", Name = "HR", NormalizedName = "HR", ConcurrencyStamp = "cb2b30ae-c597-461f-9978-2b6a3177b982" }
            );
        }
    }
}
