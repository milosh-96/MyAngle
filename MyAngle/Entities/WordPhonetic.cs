using MyAngle.Mvc.Entities;

namespace MyAngle.Mvc.Features.Dictionary.Dictionary
{
    public class WordPhonetic : BaseEntity
    {
        public string Audio { get; set; } = "";
        public string SourceUrl { get; set; } = "";
    }
}
