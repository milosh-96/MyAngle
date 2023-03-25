namespace MyAngle.Mvc.Entities
{
    public class NamedEntity : BaseEntity
    {
        public string Name { get; set; } = "Undefined";

        public override string ToString()
        {
            return this.Name;
        }
    }
}
