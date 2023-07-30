using BlogAppMVC.Contracts;
using BlogAppMVC.Dto;
using BlogAppMVC.Mappings;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppMVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly IRepositoryManager _repositoryManager;

        public BlogController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        // GET: BlogController
        public async Task<ActionResult> Index()
        {
            var blogs = await _repositoryManager.Blog.GetAllBlogs();
            var model = blogs.ToList().MapToBlogDetailDto();

            return View(model);
        }

        // GET: BlogController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BlogController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BlogDetailsVM blogToCreate)
        {
            if (!ModelState.IsValid)
            {
                return View(blogToCreate);
            }
            var blogEntity = blogToCreate.MapBlog();
            blogEntity.CreatedOn = DateTime.Now;
            _repositoryManager.Blog.CreateBlog(blogEntity);
            _repositoryManager.Save();

            return RedirectToAction(nameof(Index));
        }

        // GET: BlogController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var blog = await _repositoryManager.Blog.GetBlogById(id);
            var model = blog.MapToBlogDetails();
            return View(model);
        }

        // POST: BlogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(BlogDetailsVM updateBlog)
        {
            var blog = await _repositoryManager.Blog.GetBlogById(updateBlog.Id);
            blog.Name = updateBlog.Name;
            blog.Description = updateBlog.Description;

            _repositoryManager.Blog.UpdateBlog(blog);
            await _repositoryManager.Save();
            return RedirectToAction(nameof(Index));
        }

        // GET: BlogController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var blog = await _repositoryManager.Blog.GetBlogById(id);
            var model = blog.MapToBlogDetails();
            return View(model);
        }

        // POST: BlogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, BlogDetailsVM blogDetails)
        {
            var blog = await _repositoryManager.Blog.GetBlogById(id);
            _repositoryManager.Blog.DeleteBlog(blog);
            await _repositoryManager.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}