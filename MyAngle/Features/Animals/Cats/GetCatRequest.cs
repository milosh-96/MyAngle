using MediatR;

namespace MyAngle.Mvc.Features.Animals.Cats
{
    public class GetCatRequest : IRequest<GetCatResponse>
    {
    }
}
