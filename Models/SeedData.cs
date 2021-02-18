using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment5.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            BookDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BookDbContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if(!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book
                    {
                        Title = "Hunger Games",
                        Author = "Susan Colins",
                        Publisher = "Scholastic Corporation",
                        ISBN = "123-4564564561",
                        Category = "Young Adult",
                        Price = 15.34
                    },
                    
                    new Book
                    {
                        Title = "Catching Fire",
                        Author = "Susan Colins",
                        Publisher = "Scholastic Corporation",
                        ISBN = "123-4564564562",
                        Category = "Young Adult",
                        Price = 22.00
                    },

                    new Book
                    {
                        Title = "Mocking Bird",
                        Author = "Susan Colins",
                        Publisher = "Scholastic Corporation",
                        ISBN = "123-4564564563",
                        Category = "Young Adult",
                        Price = 30.55
                    });

                context.SaveChanges();
            }
        }
    }
}
