using BlogAppMVC.Models;

namespace BlogAppMVC.Contracts
{
    public interface IBlogRepository
    {
        Task<ICollection<Blog>> GetAllBlogs();

        Task<Blog> GetBlogById(int id);

        void CreateBlog(Blog blog);

        void DeleteBlog(Blog blog);

        void UpdateBlog(Blog blog);
    }
}