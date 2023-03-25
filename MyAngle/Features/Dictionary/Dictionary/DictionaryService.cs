using MyAngle.Mvc.Entities;
using MyAngle.Mvc.Features.Animals.Dogs;
using System.Text.Json;

namespace MyAngle.Mvc.Features.Dictionary.Dictionary
{
    public class DictionaryService : IDictionaryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<DictionaryService> _logger;

        public DictionaryService(IHttpClientFactory httpClientFactory, ILogger<DictionaryService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<Word?> Get(string query)
        {
            // Create the client
            using HttpClient client = _httpClientFactory.CreateClient();

            Word? item = null;
            List<GetWordApiResponse>? response = new List<GetWordApiResponse>();
            try
            {
                // Make HTTP GET request
                // Parse JSON response deserialize into Todo types
                response = await client.GetFromJsonAsync<List<GetWordApiResponse>>(
                "https://api.dictionaryapi.dev/api/v2/entries/en/"+query,
                new JsonSerializerOptions(JsonSerializerDefaults.Web));

                if (response != null && response.Count > 0)
                {
                    GetWordApiResponse? responseItem = response.FirstOrDefault();
                    if (responseItem != null && responseItem.Word != null)
                    {
                        item = new Word();
                        item.Name = responseItem.Word;
                        if (responseItem.Phonetic != null)
                        {
                            item.Phonetic = responseItem.Phonetic;
                        }
                        item.Meanings = responseItem.Meanings;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting something fun to say: {Error}", ex);
            }

            return item;
        }
    }
}
