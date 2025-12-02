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
        [HttpPost]
        [ActionName("Add")]
        public IActionResult SubmitTag()
        {
            var name = Request.Form["name"];
            var displayname = Request.Form["diplayName"];

            return View("Add");
        }
    }
}
