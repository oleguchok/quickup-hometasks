using Solid.SingleResponsibility.Builder;

namespace Solid.SingleResponsibility
{
    public class ToyPresenter
    {
        private readonly IToyBuilder _toyBuilder;

        public ToyPresenter(IToyBuilder toyBuilder)
        {
            _toyBuilder = toyBuilder;
        }

        public Toy PresentToyToChildren()
        {
            return _toyBuilder.BuildToy();
        }
    }
}
