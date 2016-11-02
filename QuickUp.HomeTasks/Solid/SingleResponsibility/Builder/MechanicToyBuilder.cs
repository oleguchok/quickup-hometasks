namespace Solid.SingleResponsibility.Builder
{
    public class MechanicToyBuilder : IToyBuilder
    {
        public Toy BuildToy()
        {
            // mechanic toy building logic
            return new Toy {Name = "Radio car"};
        }
    }
}
