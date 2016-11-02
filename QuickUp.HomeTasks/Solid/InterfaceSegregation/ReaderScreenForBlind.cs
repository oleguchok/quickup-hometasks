using System;

namespace Solid.InterfaceSegregation
{
    public class ReaderScreenForBlind : Screen, IBlindReadable
    {
        public void ReadForBlinds()
        {
            throw new NotImplementedException();
        }
    }
}
