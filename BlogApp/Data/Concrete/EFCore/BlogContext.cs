using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EFCore
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }

        public DbSet<Entity.Post> Posts => Set<Entity.Post>();
        public DbSet<Entity.Comment> Commets => Set<Entity.Comment>();
        public DbSet<Entity.Tag> Tags => Set<Entity.Tag>();
        public DbSet<Entity.User> Users => Set<Entity.User>();
    }
}
