using System.Diagnostics;
using BlogWebsite.Interfaces;
using BlogWebsite.Models;
using BlogWebsite.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogPostRepository blogPostRepository;
        private readonly ITagRepository tagRepository;

        public HomeController(ILogger<HomeController> logger, 
            IBlogPostRepository blogPostRepository,
            ITagRepository tagRepository )
        {
            _logger = logger;
            this.blogPostRepository = blogPostRepository;
            this.tagRepository = tagRepository;
        }

        public async Task<IActionResult> Index()
        {
            //getting all blogs
            var BlogPost = await blogPostRepository.GetAllAsync();
             
            //getting all tags
            var TagPost = await tagRepository.GetAllAsync();

            var model = new HomeViewModel { 
             BlogPosts = BlogPost,
             Tags = TagPost
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
