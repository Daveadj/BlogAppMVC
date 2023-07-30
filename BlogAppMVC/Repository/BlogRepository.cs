using BlogAppMVC.Contracts;
using BlogAppMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAppMVC.Repository
{
    public class BlogRepository : RepositoryBase<Blog>, IBlogRepository
    {
        public BlogRepository(BlogPostMVCDbContext context)
           : base(context)
        {
        }

        public void CreateBlog(Blog blog)
        {
            Create(blog);
        }

        public void DeleteBlog(Blog blog)
        {
            Delete(blog);
        }

        public async Task<ICollection<Blog>> GetAllBlogs() => await FindAll().ToListAsync();

        public async Task<Blog> GetBlogById(int id) => await FindByCondition(b => b.Id == id).FirstOrDefaultAsync();

        public void UpdateBlog(Blog blog)
        {
            Update(blog);
        }
    }
}