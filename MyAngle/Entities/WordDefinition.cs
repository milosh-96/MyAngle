using MyAngle.Mvc.Entities;

namespace MyAngle.Mvc.Features.Dictionary.Dictionary
{
    public class WordDefinition : BaseEntity
    {
        public string Definition { get; set; } = "";
        public string Example { get; set; } = "";
    }
}
