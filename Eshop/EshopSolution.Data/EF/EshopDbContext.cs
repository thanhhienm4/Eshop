using EshopSolution.Data.Configurations;
using EshopSolution.Data.Entities;
using EshopSolution.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace EshopSolution.Data.EF
{
    public class EshopDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public EshopDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new PromotionConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

            modelBuilder.Entity<Cart>().Property(p => p.Price).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<OrderDetail>().Property(p => p.Price).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Product>().Property(p => p.OriginalPrice).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Promotion>().Property(p => p.DiscountAmount).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Transaction>().Property(p => p.Amount).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Transaction>().Property(p => p.Fee).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,4)");

            //Data seeding
            modelBuilder.Seed();
            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<AppConfig> AppConfigs { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        public DbSet<ProductInCategory> ProductInCategories { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }

        public DbSet<Promotion> Promotions { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }
    }
}