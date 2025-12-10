using Microsoft.AspNetCore.Mvc;

namespace BlogWebsite.Controllers
{
    public class AdminBlogPostController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
    }
}
