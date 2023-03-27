using MediatR;

namespace MyAngle.Mvc.Features.Animals.Dogs
{
    public class GetDogRequest : IRequest<GetDogResponse>
    {
    }
}
