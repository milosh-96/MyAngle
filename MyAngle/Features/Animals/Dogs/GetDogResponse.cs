namespace MyAngle.Mvc.Features.Animals.Dogs
{
    public class GetDogResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Undefined";
        public string Description { get; set; } = "";
        public string ImageUrl { get; set; } = "";
    }
}
