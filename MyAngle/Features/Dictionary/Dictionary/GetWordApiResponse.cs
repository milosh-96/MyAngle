namespace MyAngle.Mvc.Features.Dictionary.Dictionary
{
    public class GetWordApiResponse
    {
        public string? Word { get; set; }
        public string? Phonetic { get; set; }

        public List<WordMeaning> Meanings { get; set; } = new List<WordMeaning>();
    }
}
