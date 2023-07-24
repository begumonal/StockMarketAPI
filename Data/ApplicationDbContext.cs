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

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<StockBehaviour> StockBehaviours { get; set;  }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //one user has one portfolio
            builder.Entity<Portfolio>()
                .HasKey(p => p.PortfolioId);
            builder.Entity<Portfolio>()
                .HasOne(sb => sb.User)
                .WithOne(sp => sp.Portfolio)
                .HasForeignKey<Portfolio>(sb => sb.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Set the OnDelete behavior to Restrict


            //one user has one transaction
            builder.Entity<Transaction>()
                .HasKey(p => p.TransactionId);
            builder.Entity<Transaction>()
                .HasOne(sb => sb.User)
                .WithMany(sp => sp.Transactions)
                .HasForeignKey(sb => sb.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Set the OnDelete behavior to Restrict


            //one transaction has many stock behaviours
            builder.Entity<StockBehaviour>()
                .HasKey(p => new { p.StockBehaviourId, p.TransactionId });
            builder.Entity<StockBehaviour>()
                .HasOne(sb => sb.Transaction)
                .WithMany(sp => sp.StockBehaviours)
                .HasForeignKey(sp => sp.TransactionId)
                .OnDelete(DeleteBehavior.Restrict); // Set the OnDelete behavior to Restrict


            //one stock portfolio has many stock behaviours
            builder.Entity<StockBehaviour>()
                .HasKey(p => new { p.StockBehaviourId, p.StockId });
            builder.Entity<StockBehaviour>()
                .HasOne(sb => sb.Stock)
                .WithMany(sp => sp.StockBehaviours)
                .HasForeignKey(sb => sb.StockId )
                .OnDelete(DeleteBehavior.Restrict); // Set the OnDelete behavior to Restrict


            //one portfolio has many stock behaviours
            builder.Entity<StockBehaviour>()
                .HasKey(p => new { p.StockBehaviourId, p.PortfolioId });
            builder.Entity<StockBehaviour>()
                .HasOne(sb => sb.Portfolio)
                .WithMany(sp => sp.StockBehaviours)
                .HasForeignKey(sb => sb.PortfolioId)
                .OnDelete(DeleteBehavior.Restrict); // Set the OnDelete behavior to Restrict








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
       
    

            /*
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
            */

        }
        

    }
}

