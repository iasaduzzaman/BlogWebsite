using Microsoft.AspNetCore.Mvc;

namespace BlogWebsite.Controllers
{
    public class AdminTagsController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
