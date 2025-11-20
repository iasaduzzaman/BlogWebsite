using BlogWebsite.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogWebsite.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions option) : base(option)
        {

        }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
