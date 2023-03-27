using MediatR;
using MyAngle.Mvc.Entities;
using MyAngle.Mvc.Features.Dictionary.Dictionary;
using System.Net.Http;
using System.Text.Json;

namespace MyAngle.Mvc.Features.Dictionary.Search
{
    public class SearchWordHandler : IRequestHandler<SearchWordRequest,SearchWordResponse>
    {
        

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<GetWordHandler> _logger;

        public SearchWordHandler(IHttpClientFactory httpClientFactory, ILogger<GetWordHandler> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<SearchWordResponse> Handle(SearchWordRequest request, CancellationToken cancellationToken)
        {
            SearchWordResponse response = new SearchWordResponse();
            if((await this.Get(request.Query)) != null)
            {
                response.Found = true;
            }
            return response;
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
                       // item.Meanings = responseItem.Meanings;
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
