using MediatR;

namespace MyAngle.Mvc.Features.Animals.Cats
{
    public class GetCatHandler : IRequestHandler<GetCatRequest, GetCatResponse>
    {
        public async Task<GetCatResponse> Handle(GetCatRequest request, CancellationToken cancellationToken)
        {
            // this api is directly linking to image
            return new GetCatResponse() { ImageUrl = "https://cataas.com/cat" };
        }
    }
}
