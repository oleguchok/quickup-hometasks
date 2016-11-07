namespace Solid.SingleResponsibility.Builder
{
    public class MechanicToyBuilder : ToyBuilder
    {
        public override Toy BuildToy()
        {
            // mechanic toy building logic
            return new Toy {Name = "Radio car"};
        }
    }
}
