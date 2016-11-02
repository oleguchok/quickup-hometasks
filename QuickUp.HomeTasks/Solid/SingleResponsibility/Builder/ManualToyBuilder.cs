namespace Solid.SingleResponsibility.Builder
{
    public class ManualToyBuilder : IToyBuilder
    {
        public Toy BuildToy()
        {
            // manual toy building logic
            return new Toy {Name="Paper doll"};
        }
    }
}
