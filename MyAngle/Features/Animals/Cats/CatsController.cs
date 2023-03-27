using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MyAngle.Mvc.Features.Animals.Cats
{
    [Route("/Animals/Cats/{0=Index}")]
    public class CatsController : Controller
    {
        private readonly IMediator _mediator;

        public CatsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("", Name = "AnimalsCatsHome")]

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Animals: Cats - Index";
            CatsIndexViewModel viewModel = new CatsIndexViewModel();
            viewModel.FeaturedCat.ImageUrl = (await _mediator.Send(new GetCatRequest())).ImageUrl ?? "";
            return View(viewModel);
        }
    }
}
