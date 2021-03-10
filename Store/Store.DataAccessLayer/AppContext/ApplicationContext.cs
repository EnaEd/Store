﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Extensions;
using System;

namespace Store.DataAccessLayer.AppContext
{
    public class ApplicationContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PrintingEdition> PrintingEditions { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //extension for initialize database
            builder.Seed();

            base.OnModelCreating(builder);
        }
    }
}
