using System;

namespace Solid.InterfaceSegregation
{
    public class Screen : IScreenable
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public void Slide()
        {
            throw new NotImplementedException();
        }

        public void Scale()
        {
            throw new NotImplementedException();
        }
    }
}
