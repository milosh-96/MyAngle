using MyAngle.Mvc.Entities;

namespace MyAngle.Mvc.Features.Dictionary.Dictionary
{
    public class DictionaryIndexViewModel
    {
        public string SearchQuery { get; set; } = "Internet";
        public Word FeaturedWord = new Word();
    }
}
