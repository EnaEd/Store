using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.DataAccessLayer.Entities;
using Store.Shared.Enums;
using System;

namespace Store.DataAccessLayer.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {


            //pre generated GUID by specific Data Seeding(HasData) requirement
            string authorIdGuid = Guid.NewGuid().ToString();
            string printEditionIdGuid = Guid.NewGuid().ToString();

            string adminRoleIdGuid = Guid.NewGuid().ToString();
            string clientRoleIdGuid = Guid.NewGuid().ToString();




            modelBuilder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid>
                {
                    Id = new Guid(adminRoleIdGuid),
                    Name = UserRole.Admin.ToString(),
                    NormalizedName = UserRole.Admin.ToString().ToUpper()
                },
                new IdentityRole<Guid>
                {
                    Id = new Guid(clientRoleIdGuid),
                    Name = UserRole.Client.ToString(),
                    NormalizedName = UserRole.Client.ToString().ToUpper()
                });

            modelBuilder.Entity<Author>()
                .HasData(
                new Author
                {
                    Id = new Guid(authorIdGuid),
                    Name = "TestAuthor"
                });
            modelBuilder.Entity<PrintingEdition>()
                .HasData(
                new PrintingEdition
                {
                    Id = new Guid(printEditionIdGuid),
                    Currency = Currency.USD.ToString(),
                    Description = "init desc",
                    Price = 1,
                    Status = PayStatus.Unpaid.ToString(),
                    Title = "test Title",
                    Type = EditionType.Book.ToString()
                });
        }
    }
}
