using Microsoft.AspNetCore.Mvc;
using MyAngle.Mvc.Features.Animals.Cats;

namespace MyAngle.Mvc.Features.Animals
{
    [Route("/Animals/Cats/{0=Index}")]
    public class CatsController : Controller
    {
        [Route("",Name = "AnimalsCatsHome")]

        public IActionResult Index() {
            ViewData["Title"] = "Animals: Cats - Index";
            CatsIndexViewModel viewModel = new CatsIndexViewModel();
            viewModel.FeaturedCat.ImageUrl = "https://cataas.com/cat";
            return View(viewModel);
        }
    }
}
