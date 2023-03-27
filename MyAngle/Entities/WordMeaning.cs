using MyAngle.Mvc.Entities;

namespace MyAngle.Mvc.Features.Dictionary.Dictionary
{
    public class WordMeaning : BaseEntity
    {
        public List<WordDefinition> Definitions { get; set; } = new List<WordDefinition>();
    }
}
