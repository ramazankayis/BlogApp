using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EFCore
{
    public static class SeedData
    {

        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BlogContext>();

            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if (!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Tag { Text = "C#" },
                        new Tag { Text = "CASP.NET Core" },
                        new Tag { Text = "Entity Framework Core" },
                        new Tag { Text = "CLINQ" },
                        new Tag { Text = "Blazor" }
                    );
                    context.SaveChanges();
                }
                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User { UserName = "Admin" },
                        new User { UserName = "ramazan" },
                        new User { UserName = "bayram" }
                     );
                    context.SaveChanges();

                }
                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post
                        {
                            Title = "C# 11 Yenilikleri",
                            Content = "C# 11 ile gelen yenilikler...",
                            UserId = 1,
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList()
                        },
                        new Post
                        {
                            Title = "ASP.NET Core 7",
                            Content = "ASP.NET Core 7...",
                            UserId = 1,
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-20),
                            Tags = context.Tags.Take(2).ToList()
                        },
                         new Post
                         {
                             Title = "Entity Framework Core 7",
                             Content = "Entity Framework Core 7...",
                             UserId = 2,
                             IsActive = true,
                             PublishedOn = DateTime.Now.AddDays(-5),
                             Tags = context.Tags.Take(3).ToList()
                         }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
