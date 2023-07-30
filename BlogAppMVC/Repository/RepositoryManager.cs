using BlogAppMVC.Contracts;
using BlogAppMVC.Models;

namespace BlogAppMVC.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private BlogPostMVCDbContext _context;
        private IBlogRepository _blogRepository;
        private IPostRepository _postRepository;

        public RepositoryManager(BlogPostMVCDbContext context)
        {
            _context = context;
        }

        public IBlogRepository Blog
        {
            get
            {
                if (_blogRepository == null)
                    _blogRepository = new BlogRepository(_context);
                return _blogRepository;
            }
        }

        public IPostRepository Post
        {
            get
            {
                if (_postRepository == null)
                    _postRepository = new PostRepository(_context);
                return _postRepository;
            }
        }

        public Task Save() => _context.SaveChangesAsync();
    }
}