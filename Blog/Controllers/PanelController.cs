using System.Threading.Tasks;
using Blog.Data.FileManager;
using Blog.Data.Repository;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        private readonly IFileManager _fileManager;
        private readonly IRepository _repo;

        public PanelController(IRepository repo, IFileManager fileManager)
        {
            _repo = repo;
            _fileManager = fileManager;
        }

        public IActionResult Index()
        {
            var posts = _repo.GetAllPost();
            return View(posts);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return View(new PostViewModel());

            var post = _repo.GetPost(id.Value);
            return View(new PostViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Body = post.Body
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel postVm)
        {
            var post = new Post
            {
                Id = postVm.Id,
                Title = postVm.Title,
                Body = postVm.Body,
                Image = await _fileManager.SaveImage(postVm.Image)
            };
            if (post.Id > 0)
                _repo.UpdatePost(post);
            else
                _repo.AddPost(post);

            if (await _repo.SaveChangesAsync())
                return RedirectToAction("Index");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            _repo.RemovePost(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}