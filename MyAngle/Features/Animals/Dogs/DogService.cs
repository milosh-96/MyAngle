using MyAngle.Mvc.Entities;
using MyAngle.Mvc.Infrastructure;
using System.Text.Json;

namespace MyAngle.Mvc.Features.Animals.Dogs
{
    public class DogService : IApiRequestService<Dog>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<DogService> _logger;

        public DogService(IHttpClientFactory httpClientFactory, ILogger<DogService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<Dog> Get()
        {
            // Create the client
            using HttpClient client = _httpClientFactory.CreateClient();

            Dog item = new Dog() { Id = 1, Name = "Cute Dog", ImageUrl = "https://random.dog/17234-7028-29.jpg" };
            GetDogApiResponse? response = new GetDogApiResponse();
            try
            {
                // Make HTTP GET request
                // Parse JSON response deserialize into Todo types
                    response = await client.GetFromJsonAsync<GetDogApiResponse>(
                    "https://dog.ceo/api/breeds/image/random",
                    new JsonSerializerOptions(JsonSerializerDefaults.Web));

               if(response != null && response.Message != null)
                {
                    item.ImageUrl = response.Message;
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
