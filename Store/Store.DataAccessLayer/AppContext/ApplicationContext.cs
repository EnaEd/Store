using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Extensions;
using System;

namespace Store.DataAccessLayer.AppContext
{
    public class ApplicationContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorInPrintingEdition> AuthorInBooks { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PrintingEdition> PrintingEditions { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //extension for initialize database
            builder.Seed();

            base.OnModelCreating(builder);

            builder.Entity<UserProfileEntity>().HasNoKey();

        }
    }
    //for create instance dbContext in migration.DBContaxt withoutParametr

    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            builder.UseSqlServer("Server=DESKTOP-0R8765L\\SQLEXPRESS;Database=Storedb;Trusted_Connection=True;");
            var context = new ApplicationContext(builder.Options);
            return context;
        }
    }

}
