using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAngle.Mvc.Entities;
using MyAngle.Mvc.Features.Dictionary.Dictionary;

namespace MyAngle.Mvc.Features.Dictionary.Search
{
    [Route("/Dictionary/Search/{0=Search}")]
    public class SearchController : Controller
    {
        private readonly IMediator _mediator;

        public SearchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "DictionarySearch")]
        public async Task<IActionResult> Search(string SearchQuery)
        {
            SearchWordResponse response = await _mediator.Send(new SearchWordRequest(SearchQuery));
            if (response.Found)
            {
                return RedirectToAction("SingleWord", "Dictionary", new { word = SearchQuery});
            }
            TempData["Error"] = "This word hasn't been found.";
            return RedirectToAction("Index", "Dictionary");
        }
    }
}
