using System.Collections.Generic;

namespace Solid.LiskovSubstitution
{
    public class LegsBreaker
    {
        public void BrokeLegs(IEnumerable<Creature> creatures)
        {
            foreach (var creature in creatures)
            {
                var breakable = creature as ILegsBreakable;
                breakable?.BreakLegs();
            }
        }
    }
}
