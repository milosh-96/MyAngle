using MyAngle.Mvc.Entities;

namespace MyAngle.Mvc.Features.Dictionary.Dictionary
{
    public class SingleWordViewModel
    {
        public Word Word { get; set; } = new Word();
        public List<WordDefinition> Definitions { get; set; } = new List<WordDefinition>();
    }
}
