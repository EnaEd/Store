using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.DataAccessLayer.Entities;

namespace Store.DataAccessLayer.AppContext
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Order> Orders { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
