using Microsoft.EntityFrameworkCore;

namespace BlogAppMVC.Models
{
    public class BlogPostMVCDbContext : DbContext
    {
        public BlogPostMVCDbContext(DbContextOptions options)
           : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<BlogAppMVC.Dto.BlogDetailsVM> BlogDetailsVM { get; set; } = default!;
    }
}