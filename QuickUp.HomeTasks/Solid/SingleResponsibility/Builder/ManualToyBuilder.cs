namespace Solid.SingleResponsibility.Builder
{
    public class ManualToyBuilder : ToyBuilder
    {
        public override Toy BuildToy()
        {
            // manual toy building logic
            return new Toy {Name="Paper doll"};
        }
    }
}
