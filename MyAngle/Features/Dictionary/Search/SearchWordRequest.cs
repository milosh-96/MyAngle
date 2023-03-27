using MediatR;

namespace MyAngle.Mvc.Features.Dictionary.Search
{       
    
    /// <summary>
    /// This request will return response with (bool)Found property if the word is found. Then it's up to the receiver of the
    /// response to decide what to do next with that true/false information.
    /// </summary>
    /// <remarks>
    /// The idea here is that this search request shouldn't return an object (word), but whether
    /// the query has the result or it doesn't.
    /// . For the consumer (receiver) is to retrieve the actual word from the data source.
    /// </remarks>
    public class SearchWordRequest : IRequest<SearchWordResponse>
    {
         
        public string Query { get; set; } = "";

        public SearchWordRequest(string query)
        {
            Query = query;
        }
    }
}
