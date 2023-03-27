using MediatR;
using MyAngle.Mvc.Entities;
using System.Net.Http;
using System.Text.Json;

namespace MyAngle.Mvc.Features.Dictionary.Dictionary
{
    public class GetWordHandler : IRequestHandler<GetWordRequest,Word>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<GetWordHandler> _logger;

        public GetWordHandler(IHttpClientFactory httpClientFactory, ILogger<GetWordHandler> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<Word> Handle(GetWordRequest request, CancellationToken cancellationToken)
        {
            if (request != null && request.Query != null)
            {
                return await this.Get(request.Query);
            }
            throw new Exception("You must enter a word");
        }

        private async Task<Word?> Get(string query)
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
                "https://api.dictionaryapi.dev/api/v2/entries/en/" + query,
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
                        item.Phonetics = responseItem.Phonetics;
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
    internal class GetWordApiResponse
    {
        public string? Word { get; set; }
        public string? Phonetic { get; set; }

        public List<WordPhonetic> Phonetics { get; set; } = new List<WordPhonetic>();
        public List<WordMeaning> Meanings { get; set; } = new List<WordMeaning>();
    }
}
