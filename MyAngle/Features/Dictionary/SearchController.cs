using Microsoft.AspNetCore.Mvc;
using MyAngle.Mvc.Entities;
using MyAngle.Mvc.Features.Dictionary.Dictionary;

namespace MyAngle.Mvc.Features.Dictionary
{
    [Route("/Dictionary/Search/{0=Search}")]
    public class SearchController : Controller
    {
        private readonly IDictionaryService _dictionaryService;

        public SearchController(IDictionaryService dictionaryService)
        {
            _dictionaryService = dictionaryService;
        }

        [HttpGet(Name ="DictionarySearch")]
        public async Task<IActionResult> Search(string SearchQuery)
        {
            Word? item = await _dictionaryService.Get(SearchQuery);
            if(item!=null)
            {
                return RedirectToAction("SingleWord","Dictionary", new {word=item.Name});
            }
            TempData["Error"] = "This word hasn't been found.";
            return RedirectToAction("Index","Dictionary");
        }
    }
}
