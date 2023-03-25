using Microsoft.AspNetCore.Mvc;

namespace MyAngle.Mvc.Features.Sports
{
    public class SportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
