using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using StockMarket_begum.Models;

namespace StockMarket_begum.Data
{
    public class ApplicationDbContext : IdentityDbContext<CustomUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1",
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = null
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = null
                }
            );
       
    

            
            var adminUserId = "admin-user-id";
            var adminRoleId = "2"; // Admin role Id
            builder.Entity<CustomUser>().HasData(
                new CustomUser
                {
                    Id = adminUserId,
                    UserName = "adminuser",
                    NormalizedUserName = "ADMINUSER",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = null,
                    SecurityStamp = null,
                    ConcurrencyStamp = null,
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    Address = "admin-address",
                    BirthDate = DateTime.Today,
                    FullName = "admin",
                    Gender = "male"
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = adminUserId
                }
            );

        }

    }
}

