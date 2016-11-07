namespace Solid.LiskovSubstitution
{
    public class Human : Creature, ILegsBreakable
    {
        public void BreakLegs() => Name += "WithBrokenLegs";
    }
}
