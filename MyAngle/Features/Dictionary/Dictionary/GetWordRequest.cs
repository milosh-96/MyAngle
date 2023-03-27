using MediatR;
using MyAngle.Mvc.Entities;

namespace MyAngle.Mvc.Features.Dictionary.Dictionary
{
    public class GetWordRequest : IRequest<Word>
    {
        public string? Query { get; set; }

        public GetWordRequest(string? query)
        {
            Query = query;
        }
    }
}
