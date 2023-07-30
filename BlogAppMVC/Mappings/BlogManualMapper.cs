using BlogAppMVC.Dto;
using BlogAppMVC.Models;

namespace BlogAppMVC.Mappings
{
    public static class BlogManualMapper
    {
        public static Blog MapBlog(this BlogDetailsVM blogDetailsDto)
        {
            var blog = new Blog
            {
                Id = blogDetailsDto.Id,
                Description = blogDetailsDto.Description,
                Name = blogDetailsDto.Name,
                CreatedOn = blogDetailsDto.CreatedOn,
            };

            return blog;
        }

        public static BlogDetailsVM MapToBlogDetails(this Blog blog)
        {
            var blogDetails = new BlogDetailsVM
            {
                Id = blog.Id,
                Description = blog.Description,
                Name = blog.Name,
                CreatedOn = blog.CreatedOn,
            };

            return blogDetails;
        }

        public static Blog MapToBlog(this BlogVM blogDto)
        {
            var newBlog = new Blog
            {
                Name = blogDto.Name,
                Description = blogDto.Description,
            };
            return newBlog;
        }

        public static List<BlogDetailsVM> MapToBlogDetailDto(this List<Blog> blogList)
        {
            var newBlogList = new List<BlogDetailsVM>();
            foreach (var blog in blogList)
            {
                var blogDetails = new BlogDetailsVM
                {
                    Id = blog.Id,
                    Description = blog.Description,
                    Name = blog.Name,
                    CreatedOn = blog.CreatedOn,
                };
                newBlogList.Add(blogDetails);
            }
            return newBlogList;
        }
    }
}