using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Shop.DataAcces
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            User user = new User
            {
                Id = "e17cbb1b-adea-43b0-af7f-33c85a5cb976",
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "admin@shop.com",
                NormalizedUserName = "ADMIN@SHOP.COM",
                Email = "admin@shop.com",
                NormalizedEmail = "ADMIN@SHOP.COM"
            };
            user.PasswordHash = new PasswordHasher<User>().HashPassword(user, "1234");

            modelBuilder.Entity<User>().HasData(user);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                    {
                        Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                        Name = "Administrator",
                        NormalizedName = "ADMINISTRATOR".ToUpper()
                    },
                new IdentityRole
                {
                    Id = "ace800ca-6df1-415a-9cf4-2c48f3f125ba",
                    Name = "User",
                    NormalizedName = "USER".ToUpper()
                });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
               new IdentityUserRole<string>
               {
                   RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                   UserId = "e17cbb1b-adea-43b0-af7f-33c85a5cb976"
               }
           );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Product> Products { get; set; }

    }
}
