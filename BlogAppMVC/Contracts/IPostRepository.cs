using BlogAppMVC.Models;

namespace BlogAppMVC.Contracts
{
    public interface IPostRepository
    {
        Task<ICollection<Post>> GetAllPost(int blogId);

        Task<Post> GetPostById(int postId);

        void CreatePost(Post post);

        void DeletePost(Post post);

        void UpdatePost(Post post);
    }
}