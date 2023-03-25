using Microsoft.AspNetCore.Mvc;
using MyAngle.Mvc.Entities;
using MyAngle.Mvc.Features.Dictionary.Dictionary;

namespace MyAngle.Mvc.Features.Dictionary
{
    public class DictionaryController : Controller
    {
        private readonly IDictionaryService _dictionaryService;

        public DictionaryController(IDictionaryService dictionaryService)
        {
            _dictionaryService = dictionaryService;
        }

        [HttpGet(Name="DictionaryHome")]
        [HttpPost(Name="DictionaryHome")]
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Dictionary: Words and Definitions - Index";
            DictionaryIndexViewModel viewModel = new DictionaryIndexViewModel();
            Word? word = await _dictionaryService.Get("World");
            if (word != null) { viewModel.FeaturedWord = word; }
            return View(viewModel);
        }

        [HttpGet(Name ="DictionarySingleWord")]
        public async Task<IActionResult> SingleWord([FromQuery] string word)
        {
            Word? item = null;
            item = await _dictionaryService.Get(word);
            if(item == null) { return new NotFoundResult(); }
            SingleWordViewModel viewModel = new SingleWordViewModel() { Word = item };
            if (item.Meanings.Any())
            {
                var meaning = item.Meanings.FirstOrDefault();
                if (meaning != null)
                {
                    viewModel.Definitions.AddRange(meaning.Definitions);
                }
            }
            return View(viewModel);
        } 
    }
}
