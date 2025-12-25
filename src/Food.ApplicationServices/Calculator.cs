namespace UI_MVC.Services
{
    public class Calculator : ICalculator
    {
        public Calculator(IRealNumbers realNumbers)
        {

        }

        public int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
