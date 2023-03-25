using Microsoft.AspNetCore.Mvc;

namespace MyAngle.Mvc.Features.Animals
{
    public class AnimalsController : Controller
    {
        [HttpGet(Name ="AnimalsHome")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
