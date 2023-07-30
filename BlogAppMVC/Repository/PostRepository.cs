using BlogAppMVC.Contracts;
using BlogAppMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAppMVC.Repository
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(BlogPostMVCDbContext context)
           : base(context)
        {
        }

        public void CreatePost(Post post)
        {
            Create(post);
        }

        public void DeletePost(Post post)
        {
            Delete(post);
        }

        public async Task<ICollection<Post>> GetAllPost(int blogId)
            => await FindByCondition(b => b.BlogId == blogId)
            .ToListAsync();

        public async Task<Post> GetPostById(/*int blogId,*/ int postId)
            => await FindByCondition(b => b.Id == postId).FirstOrDefaultAsync();

        public void UpdatePost(Post post)
        {
            Update(post);
        }
    }
}