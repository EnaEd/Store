

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.DAL.Entities;

namespace Store.DAL.AppContext
{
    public class AppContext : IdentityDbContext<Users>
    {
        public DbSet<Authors> Authors { get; set; }
        public DbSet<UserInRoles> UserInRoles { get; set; }
        public DbSet<AuthorInBooks> AuthorInBooks { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<PrintingEditions> PrintingEditions { get; set; }

        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
