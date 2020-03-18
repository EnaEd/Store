using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.DAL.Entities;
using System.Collections.Generic;

namespace Store.DAL.AppContext
{
    public class AppContext : IdentityDbContext<User>
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
        public DbSet<AuthorInBook> AuthorInBooks { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PrintingEdition> PrintingEditions { get; set; }

        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Author>().HasData(new Author { Id = 1, IsRemoved = false, Name = "Miguel de Cervantes" });
            builder.Entity<PrintingEdition>().HasData(new PrintingEdition
            {
                Id = 1,
                IsRemoved = false,
                Currency = "USD",
                Description = "Alonso Quixano, a retired country gentleman in his fifties, lives in an unnamed section of La Mancha with his niece and a housekeeper. ",
                Price = 100,
                Status = 0,
                Title = "Don Quixote",
                Type = 1
            });

               
        }
    }
}
