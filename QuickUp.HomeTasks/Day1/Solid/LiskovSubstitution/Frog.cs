namespace Solid.LiskovSubstitution
{
    public class Frog : Creature, ILegsBreakable
    {
        public void BreakLegs() => Name += "WithBrokenLegs";
    }
}
