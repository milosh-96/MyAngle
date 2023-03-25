using MyAngle.Mvc.Entities;

namespace MyAngle.Mvc.Features.Dictionary.Dictionary
{
    public interface IDictionaryService
    {
        public Task<Word?> Get(string query);
    }
}
