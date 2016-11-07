using Solid.SingleResponsibility.Builder;
using Solid.SingleResponsibility.Wrapper;

namespace Solid.SingleResponsibility
{
    public class ToyPresenter
    {
        private readonly ToyBuilder _toyBuilder;
        private readonly IWrapperable _wrapper;

        public ToyPresenter(ToyBuilder toyBuilder, IWrapperable wrapper)
        {
            _toyBuilder = toyBuilder;
            _wrapper = wrapper;
        }

        public WrappedToy PresentToyToChildren()
        {
            var toy = _toyBuilder.BuildToy();
            return _wrapper.WrapToy(toy);
        }
    }
}
