namespace Solid.OpenClose
{
    public class Calculator
    {
        public int? Calculate(IComputable operation, int firstNumber, int secondNumber)
        {
            return operation?.Compute(firstNumber, secondNumber);
        }

    }
}
