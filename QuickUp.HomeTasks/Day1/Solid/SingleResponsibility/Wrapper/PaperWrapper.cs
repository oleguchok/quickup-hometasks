namespace Solid.SingleResponsibility.Wrapper
{
    public class PaperWrapper : IWrapperable
    {
        public WrappedToy WrapToy(Toy toyToWrap)
        {
            return new WrappedToy
            {
                AgeLimit = toyToWrap.AgeLimit,
                Name = toyToWrap.Name,
                WrapColor = "White"
            };
        }
    }
}
