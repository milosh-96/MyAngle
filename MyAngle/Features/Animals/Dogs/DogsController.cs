using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAngle.Mvc.Entities;
using System.Xml.Linq;

namespace MyAngle.Mvc.Features.Animals.Dogs
{
    [Route("/Animals/Dogs/{0=Index}")]
    public class DogsController : Controller
    {
        private readonly IMediator _mediator;

        public DogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("", Name = "AnimalsDogsHome")]
        public async Task<IActionResult> Index()
        {

            DogsIndexViewModel viewModel = new DogsIndexViewModel();
            //
            viewModel.FeaturedDog.ImageUrl = (await _mediator.Send(new GetDogRequest())).ImageUrl ?? "";
            ViewData["Title"] = "Animals: Dogs - Index";
            return View(viewModel);
        }
    }
}
