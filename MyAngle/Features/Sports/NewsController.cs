using Microsoft.AspNetCore.Mvc;

namespace MyAngle.Mvc.Features.Sports
{
    [Route("Sports/News/{0=Index}")]
    public class NewsController : Controller
    {
        [HttpGet(Name ="SportsNewsIndex")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
