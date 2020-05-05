﻿using Microsoft.EntityFrameworkCore;
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
                    Currency = Enums.Currency.USD.ToString(),
                    Description = "init desc",
                    Price = 1,
                    Status = Enums.PayStatus.Unpaid.ToString(),
                    Title = "test Title",
                    Type = Enums.EditionType.Book.ToString()
                });

            modelBuilder.Entity<AuthorInPrintingEdition>()
                .HasOne(x => x.Author)
                .WithMany(x => x.AuthorInPrintingEditions)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<AuthorInPrintingEdition>()
                .HasOne(x => x.Edition)
                .WithMany(x => x.AuthorInPrintingEditions)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
