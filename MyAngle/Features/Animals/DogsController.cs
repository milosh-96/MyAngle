using Microsoft.AspNetCore.Mvc;
using MyAngle.Mvc.Entities;
using MyAngle.Mvc.Features.Animals.Dogs;
using MyAngle.Mvc.Infrastructure;
using System.Xml.Linq;

namespace MyAngle.Mvc.Features.Animals
{
    [Route("/Animals/Dogs/{0=Index}")]
    public class DogsController : Controller
    {
        private readonly IApiRequestService<Dog> _apiRequestService;

        public DogsController(IApiRequestService<Dog> apiRequestService)
        {
            _apiRequestService = apiRequestService;
        }

        [Route("",Name ="AnimalsDogsHome")]
        public async Task<IActionResult> Index(string? query) { 
            
            DogsIndexViewModel viewModel = new DogsIndexViewModel();
            viewModel.FeaturedDog = await _apiRequestService.Get();
            ViewData["Title"] = "Animals: Dogs - Index";
            return View(viewModel); }
    }
}
