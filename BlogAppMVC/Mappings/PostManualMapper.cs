using BlogAppMVC.Dto;
using BlogAppMVC.Models;

namespace BlogAppMVC.Mappings
{
    public static class PostManualMapper
    {
        public static Post MapPost(this PostDetailsVM postDetails)
        {
            var post = new Post
            {
                Id = postDetails.Id,
                Name = postDetails.Name,
                Content = postDetails.Content,
                BlogId = postDetails.BlogId,
                DateCreated = postDetails.DateCreated,
                LastModified = postDetails.LastModified,
            };
            return post;
        }

        public static PostDetailsVM MapToPostDetails(this Post post)
        {
            var postDetails = new PostDetailsVM
            {
                Id = post.Id,
                Name = post.Name,
                Content = post.Content,
                BlogId = post.BlogId,
                DateCreated = post.DateCreated,
                LastModified = post.LastModified,
            };
            return postDetails;
        }

        public static Post MapToPost(this PostVM postDto)
        {
            var newPost = new Post
            {
                Name = postDto.Name,
                Content = postDto.Content,
            };
            return newPost;
        }

        public static List<PostDetailsVM> MapToPostDetailDto(this List<Post> postList)
        {
            var newPostList = new List<PostDetailsVM>();
            foreach (var post in postList)
            {
                var postDetails = new PostDetailsVM
                {
                    Id = post.Id,
                    Name = post.Name,
                    Content = post.Content,
                    BlogId = post.BlogId,
                    DateCreated = post.DateCreated,
                    LastModified = post.LastModified,
                };
                newPostList.Add(postDetails);
            }
            return newPostList;
        }
    }
}