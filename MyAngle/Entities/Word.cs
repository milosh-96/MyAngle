using MyAngle.Mvc.Features.Dictionary.Dictionary;

namespace MyAngle.Mvc.Entities
{
    public class Word : NamedEntity
    {
        public string Phonetic { get; set; } = "";

        public List<WordMeaning> Meanings { get; set; } = new List<WordMeaning>();
        public List<WordPhonetic> Phonetics { get; set; } = new List<WordPhonetic>();
    }
}
