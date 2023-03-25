using Microsoft.AspNetCore.Mvc;

namespace MyAngle.Mvc.Features.Videos
{
    public class VideosController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "MyAngle Videos";
            return View();
        }
    }
}
