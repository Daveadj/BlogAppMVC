using BlogAppMVC.Contracts;
using BlogAppMVC.Dto;
using BlogAppMVC.Mappings;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppMVC.Controllers
{
    public class PostController : Controller
    {
        private readonly IRepositoryManager _repositoryManager;

        public PostController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        // GET: PostController
        public async Task<ActionResult> Index(int id)
        {
            var posts = await _repositoryManager.Post.GetAllPost(id);
            var postToReturn = posts.ToList().MapToPostDetailDto();

            ViewData["blogId"] = id;
            return View(postToReturn);
        }

        // GET: PostController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var post = await _repositoryManager.Post.GetPostById(id);
            var model = post.MapToPostDetails();
            return View(model);
        }

        // GET: PostController/Create
        public ActionResult Create(int id)
        {
            ViewData["blogId"] = id;
            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int id, [FromForm] PostDetailsVM detailsDto)
        {
            detailsDto.BlogId = id;
            var postEntity = detailsDto.MapPost();

            postEntity.LastModified = DateTime.Now;
            postEntity.DateCreated = DateTime.Now;
            _repositoryManager.Post.CreatePost(postEntity);
            await _repositoryManager.Save();
            return RedirectToAction(nameof(Index), new { id });
        }

        // GET: PostController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var post = await _repositoryManager.Post.GetPostById(id);
            var model = post.MapToPostDetails();
            return View(model);
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PostDetailsVM postDetails)
        {
            var post = await _repositoryManager.Post.GetPostById(postDetails.Id);
            post.Name = postDetails.Name;
            post.Content = postDetails.Content;
            post.LastModified = DateTime.Now;

            _repositoryManager.Post.UpdatePost(post);
            await _repositoryManager.Save();
            return RedirectToAction(nameof(Index), new { id = post.BlogId });
        }

        // GET: PostController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var post = await _repositoryManager.Post.GetPostById(id);
            ViewData["blogid"] = post.BlogId;
            var model = post.MapToPostDetails();
            return View(model);
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, PostDetailsVM postDetails)
        {
            var post = await _repositoryManager.Post.GetPostById(id);
            var blogId = post.BlogId;
            _repositoryManager.Post.DeletePost(post);
            await _repositoryManager.Save();
            return RedirectToAction(nameof(Index), new { id = blogId });
        }
    }
}